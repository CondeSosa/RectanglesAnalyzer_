// Needs interact.js framework reference for this to work properly => https://interactjs.io 


function dragRectangle(RegId) {

    var element = document.getElementById(RegId)

    //Set elements current location
    var rect = element.getBoundingClientRect();
    var positionX = rect.x; var positionY = rect.y;

    interact(element).resizable({

        // resize from all edges and corners
        edges: { left: false, right: true, bottom: true, top: false },
        listeners: {
            move(event) {
          
                var x = positionX 
                var y = positionY 

                var target = event.target

                // update the element's style
                target.style.width = event.rect.width + 'px'
                target.style.height = event.rect.height + 'px'
                target.style.transform = 'translate(' + x + 'px,' + y + 'px)'
            }
        }

    }).draggable({

        listeners: {
                move(event) {
                //update elements position
                positionX += event.dx
                positionY += event.dy
                event.target.style.transform = 'translate(' + positionX + 'px, ' + positionY + 'px)'
                        }
            }
    })
};


function GetElementPosition(RegId) {
    //Get elements position
    return document.getElementById(RegId).getBoundingClientRect();

};