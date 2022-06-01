var c = document.getElementById("canvas");
var ctx = c.getContext("2d");

let path1 = new Path2D();
path1.rect(4, 4, 992, 392);


var village_img = new Image();
village_img.src = '/images/village_pic.png';
village_img.onload = drawImageActualSize;

var pointer_img = new Image();
pointer_img.src = '/images/pointer.png';

var logElemX = document.querySelector(".innerX");
var logElemY = document.querySelector(".innerY");

const count = document.getElementById("Main_script").dataset.container

function drawImageActualSize() {
    canvas.width = 1000;
    canvas.height = 400;
    ctx.drawImage(this, 0, 0, canvas.width, canvas.height);
    ctx.stroke(path1);
    for (var i = 0; i < count; i++) {
        X = document.getElementById(i + "X").innerHTML
        Y = document.getElementById(i + "Y").innerHTML
        if (X != "-1" && Y != "-1") {
            ctx.drawImage(pointer_img, X, Y, 20, 29)
        }

    }


}


canvas.addEventListener('click', function (event) {
    if (ctx.isPointInPath(path1, event.offsetX, event.offsetY)) {
        ctx.drawImage(pointer_img, event.offsetX - 9, event.offsetY - 29, 20, 29)
        logElemX.innerHTML = event.offsetX - 9;
        logElemY.innerHTML = event.offsetY - 29;
    }
});