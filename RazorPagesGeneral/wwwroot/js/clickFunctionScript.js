
var logElemX = document.getElementById("X-coord");
var logElemY = document.getElementById("Y-coord");


var pointer_img = new Image();
pointer_img.src = '/images/pointer.png';

let tchbl = new Path2D();
tchbl.rect(0, 0, 4000, 4000);
ctx.stroke(tchbl);


canvas.addEventListener('click', function (event) {
    const windowInnerWidth = window.innerWidth
    var kef = canvas.width / (windowInnerWidth - 260);
    if (ctx.isPointInPath(tchbl, event.offsetX, event.offsetY)) {

        ctx.drawImage(pointer_img, event.offsetX * kef - 20, event.offsetY * kef - 47, 40, 58)

        logElemX.innerHTML = parseInt(event.offsetX * kef - 20);
        logElemY.innerHTML = parseInt(event.offsetY * kef - 47);
    }
});