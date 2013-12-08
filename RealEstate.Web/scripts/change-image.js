var imageID = 0;
function changeimage(everySeconds) {
    //change the image
    if (!imageID) {
        document.getElementById("myimage").src = "http://www.all-freeware.com/images/full/38943-nice_feathers_free_screensaver_desktop_screen_savers__nature.jpeg";
        imageID++;
    }
    else {
        if (imageID == 1) {
            document.getElementById("myimage").src = "http://www.hickerphoto.com/data/media/186/flower-bouquet-nice_12128.jpg";
            imageID++;
        } else {
            if (imageID == 2) {
                document.getElementById("myimage").src = "http://www.photos.a-vsp.com/fotodb/14_green_cones.jpg";
                imageID = 0;
            }
        }
    }
    //call same function again for x of seconds
    setTimeout("changeimage(" + everySeconds + ")", ((everySeconds) * 1000));
}
