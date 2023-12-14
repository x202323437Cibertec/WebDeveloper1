(function (customer) {
    customer.success = successReload;
    customer.pages = 1;
    customer.rowSize = 25;

    init();

    return customer;

    function successReload(pOption) {
        cibertec.closeModal(pOption);
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
