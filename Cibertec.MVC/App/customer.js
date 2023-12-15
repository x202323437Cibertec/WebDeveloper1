(function (customer) {
    customer.success = successReload;
    customer.addCustomer = addCustomerId;
    customer.removeCustomer = removeCustomerId;
    customer.validate = validate;

    customer.ids = [];
    customer.recordInUse = false;
    customer.hub = {};

    customer.pages = 1;
    customer.rowSize = 25;

    $(function () {
        connectToHub();
        init();
    });

    return customer;

    function successReload(pOption) {
        cibertec.closeModal(pOption);
    }

    function addCustomerId(pId) {
        customer.hub.server.addCustomerId(pId);
    }

    function removeCustomerId(pId) {
        customer.hub.server.removeCustomerId(pId);
    }

    function validate(pId) {
        customer.recordInUse = (customer.ids.indexOf(pId) > -1);
        if (customer.recordInUse) {
            $("#inUse").removeClass("hidden");
        }
    }

    function connectToHub() {
        customer.hub = $.connection.customerHub;
        customer.hub.client.customerStatus = customerStatus;
    }

    function customerStatus(pCustomerIds) {
        customer.ids = pCustomerIds;
        console.log(pCustomerIds);
    }

    function init() {
        $.get('/Customer/Count/' + customer.rowSize,
            function (data) {
                customer.pages = data;
                $('.pagination').bootpag({
                    total: customer.pages,
                    page: 1,
                    maxVisible: 5,
                    leaps: true,
                    firstLastUse: true,
                    first: '<--',
                    last: '-->',
                    wrapClass: 'pagination',
                    activeClass: 'active',
                    disableClass: 'disabled',
                    nextClass: 'next',
                    prevClass: 'prev',
                    lastClass: 'last',
                    firstClass: 'fist'
                }).on('page', function (event, num) {
                    getCustomers(num);
                });
                getCustomers(1);
            }
        );
    }

    function getCustomers(pNum) {
        var url = '/Customer/List/' + pNum + '/' + customer.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }
})(window.customer = window.customer || {});
