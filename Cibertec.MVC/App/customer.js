(function (customer) {
    customer.success = successReload;

    return customer;

    function successReload(pOption) {
        cibertec.closeModal(pOption);
    }

})(window.customer = window.customer || {});