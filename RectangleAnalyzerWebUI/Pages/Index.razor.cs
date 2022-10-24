using System.Security.AccessControl;
using Application.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using RectangleAnalyzerWebUI.Models;

namespace RectangleAnalyzerWebUI.Pages
{
    public partial class Index
    {

        [Parameter] public float? R1X { get; set; }
        [Parameter] public float? R1Y { get; set; } 
        [Parameter] public int? R1Width { get; set; } 
        [Parameter] public int? R1Height { get; set; } 
        [Parameter] public float? R2X { get; set; } 
        [Parameter] public float? R2Y { get; set; } 
        [Parameter] public int? R2Width { get; set; } 
        [Parameter] public int? R2Height { get; set; }


        public  Rectangle Rect1 { get; set; } = new();
        public Rectangle Rect2 { get; set; } = new();
        public List<Point> Intersections { get; set; } = new();
        public string Observation { get;  set; } = String.Empty;


        protected override void OnParametersSet()
        {
            R1X = R1X ?? 50;
            R2X = R2X ?? 250;
            R1Y = R1Y ?? 50;
            R2Y = R2Y ?? 250;

            R1Width = R1Width ?? 300;
            R2Width = R2Width ?? 300;
            R1Height = R1Height ?? 125;
            R2Height = R2Height ?? 125;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(50);
                await Js.InvokeVoidAsync("dragRectangle", "Rect1");
                await Js.InvokeVoidAsync("dragRectangle", "Rect2");
                await Task.Delay(50);
                await UpdateRectangleProperties("Rect1");
                await UpdateRectangleProperties("Rect2");
                await Task.Delay(50);
                StateHasChanged();
            }

        }

        private async Task UpdateRectangleProperties(string elementId)
        {
            var coordinates = await GetRectanglePosition(elementId);
            //To keep it a bit easy for the examples i'm going to round the results.
            if (elementId == "Rect1")
            {
                Rect1.TopLeftCorner.PositionY = (float)Math.Floor(coordinates.Y);
                Rect1.TopLeftCorner.PositionX = (float)Math.Floor(coordinates.X);
                Rect1.Width = Math.Floor(coordinates.Width);
                Rect1.Height = Math.Floor(coordinates.Height);
            }
            else if (elementId == "Rect2")
            {
                Rect2.TopLeftCorner.PositionY = (float)Math.Floor(coordinates.Y);
                Rect2.TopLeftCorner.PositionX = (float)Math.Floor(coordinates.X);
                Rect2.Width = Math.Floor(coordinates.Width);
                Rect2.Height = Math.Floor(coordinates.Height);
            }
        }

        protected async void OnMouseMove(object obj, MouseEventArgs args)
        {
           await UpdateRectangleProperties((string)obj);
        }

        //Gets rectangles current coordinates
        protected async Task<BoundingClientRect> GetRectanglePosition(string elementId)
        {
            var coordinates = await Js.InvokeAsync<BoundingClientRect>("GetElementPosition", elementId);
            return coordinates;
        }

        private async Task AnalyzeRectangles()
        {
            ClearResults();
            await UpdateRectangleProperties("Rect1");
            await UpdateRectangleProperties("Rect2");
            try
            {
                var result = RectAnalizer.AnalyceRectangles(Rect1, Rect2, 0.001f);


                if (!result.HasContainment)
                {

                    if (result.IsAdjacent)
                    {
                        if (result.AdjacentType == 1)
                        {
                            Observation += $"Is Adjacent (Proper)";
                        }
                        else if (result.AdjacentType == 2)
                        {
                            Observation += $"Is Adjacent (Sub-Line)";
                        }
                        else if (result.AdjacentType == 3)
                        {
                            Observation += $"Is Adjacent (Partial)";
                        }

                    }
                    else
                    {
                        

                        if (result.HasIntersection)
                        {
                            Observation += "Has Intersections: ";
                            Intersections = result.Intersections;

                            foreach (var inter in Intersections)
                            {
                                Observation += $"({inter.PositionX},{inter.PositionY}) ";
                            }

                        }

                        Observation += "No Containment ";
                    }


                }
                else
                {
                    Observation += "Has Containment ";
                }


                StateHasChanged();
            }
            catch (Exception ex)
            {
               await Js.InvokeVoidAsync("alert", ex.Message);
            }
        }

        private void ClearResults()
        {
            Intersections = new List<Point>();
            Observation = string.Empty;
            StateHasChanged();
        }

    }
}
