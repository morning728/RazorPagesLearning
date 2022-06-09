


var all = document.getElementsByName("pointer-drawner")
var coords = all[all.length - 1].dataset.container

var logElemX = coords.split("/")[0];
var logElemY = coords.split("/")[1];



if (logElemX != "-1" && logElemY != "-1") {
    ctx.drawImage(pointer_img, logElemX, logElemY, 40, 58);
}
