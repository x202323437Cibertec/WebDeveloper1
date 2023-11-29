﻿(function (cibertec) {
    cibertec.video = {
        videoElement: document.getElementById("IdVideo"),
        play: function () {
            if (this.videoElement.paused) {
                this.videoElement.play();
            }
        },
        pause: function () {
            if (this.videoElement.played) {
                this.videoElement.pause();
            }
        },
        stop: function () {
            this.videoElement.currentTime = 0;
        }
    };
})(window.cibertec = window.cibertec || {});
