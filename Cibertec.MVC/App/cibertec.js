(function (cibertec) {
    cibertec.getModal = getModalContent;
    cibertec.closeModal = closeModal;

    return cibertec;

    function getModalContent(url) {
        $.get(url, function (data) {
            $('.modal-body').html(data);
        })
    }

    function closeModal(pOption0) {
        $("button[data-dismiss='modal']").click();
        $('.modal-body').html("");
        modifyAlertClass(pOption0);
        setTimeout(function () {
            location.reload();
        }, 2500);
    }

    function modifyAlertClass(pOption1) {
        $("#successMsg").addClass("hidden");
        $("#deleteMsg").addClass("hidden");
        $("#editMsg").addClass("hidden");

        if (pOption1 == "create") {
            $("#successMsg").removeClass("hidden");
        }
        else if (pOption1 == "delete") {
            $("#deleteMsg").removeClass("hidden");
        }
        else if (pOption1 == "edit") {
            $("#editMsg").removeClass("hidden");
        }
    }

})(window.cibertec = window.cibertec || {});
