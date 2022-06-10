
var all = document.getElementsByName("pointer-drawner")
var coords = all[all.length - 1].dataset.container

var logElemX = coords.split("/")[0];
var logElemY = coords.split("/")[1];

var pointer_img = new Image();
pointer_img.src = '/images/pointer.png';
pointer_img.onload = func



function func() {
    ctx.drawImage(pointer_img, logElemX, logElemY, 40, 58);
}
