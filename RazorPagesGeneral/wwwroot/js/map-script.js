var c = document.getElementById("canvas");
var ctx = c.getContext("2d");

var village_img = new Image();
village_img.src = document.getElementById("canvas").dataset.container;
village_img.onload = drawImageActualSize;

var pointer_img = new Image();
pointer_img.src = '/images/pointer.png';

const count = document.getElementById("Main_script").dataset.container
function drawImageActualSize() {
    canvas.width = this.naturalWidth;
    canvas.height = this.naturalHeight;
    ctx.drawImage(this, 0, 0, canvas.width, canvas.height);
}
