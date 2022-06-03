var c = document.getElementById("canvas");
var ctx = c.getContext("2d");


let tchbl = new Path2D();

var village_img = new Image();
village_img.src = '/images/viltest1.jpg';
village_img.onload = drawImageActualSize;

var pointer_img = new Image();
pointer_img.src = '/images/pointer.png';

var logElemX = document.querySelector(".innerX");
var logElemY = document.querySelector(".innerY");

const count = document.getElementById("Main_script").dataset.container

function drawImageActualSize() {
    canvas.width = this.naturalWidth;
    canvas.height = this.naturalHeight;
    tchbl.rect(0, 0, 4000, 4000);
    ctx.drawImage(this, 0, 0, canvas.width, canvas.height);
    ctx.stroke(tchbl);
    for (var i = 0; i < count; i++) {
        X = document.getElementById(i + "X").innerHTML
        Y = document.getElementById(i + "Y").innerHTML
        if (X != "-1" && Y != "-1") {
            ctx.drawImage(pointer_img, X, Y, 40, 58)
        }

    }


}


canvas.addEventListener('click', function (event) {
    const windowInnerWidth = window.innerWidth
    var kef = canvas.width / (windowInnerWidth-260);
    if (ctx.isPointInPath(tchbl, event.offsetX, event.offsetY)) {
        ctx.drawImage(pointer_img, event.offsetX * kef - 20, event.offsetY * kef - 47, 40, 58)
        //alert(windowInnerWidth);

        logElemX.innerHTML = event.offsetX  - 20;
        logElemY.innerHTML = event.offsetY - 47;

        
        
        
    }
});