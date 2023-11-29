(function (cibertec) {
    cibertec.index = {
        currentyear: function () {
            var today = new Date();
            return today.getFullYear();
        }
    };
    document.getElementById("fecha").innerHTML = cibertec.index.currentyear();
})(window.cibertec = window.cibertec || {});