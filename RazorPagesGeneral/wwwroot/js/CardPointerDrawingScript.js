var c = document.getElementById("canvas");
var ctx = c.getContext("2d");

var pointer_img = new Image();
pointer_img.src = '/images/pointer.png';

var all = document.getElementsByName("pointer-drawner")
var coords = all[all.length - 1].dataset.container

var logElemX = coords.split("/")[0];
var logElemY = coords.split("/")[1];
pointer_img.onload = draw_pointer;

if (logElemX != "-1" && logElemY != "-1") { pointer_img.onload = draw_pointer; }

function draw_pointer() {
    ctx.drawImage(pointer_img, logElemX, logElemY, 40, 58);
}