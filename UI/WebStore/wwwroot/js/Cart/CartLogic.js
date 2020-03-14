Cart = {
    _properties: {
        getCartViewLink: "",
        addToCartLink: ""
    },

    init: function (properties) {
        $.extend(Cart._properties, propeties);
        Cart.initEvents();
    },

    initEvents: function () {
        $(".add-to-cart").click(Cart.addToCart());
    },

    addToCart: function (event) {
        event.preventDefault();
        var button = $(this);
        const id = button.data("id");
        $.get(Cart._properties.addToCartLink + '/' + id).done(function () {
            Cart.showToolTip(button);
            Cart.refreshCartView();
        }).fail(function () { console.log("error"); });
    },

    refreshCartView: function () {
        var container = $("#cartContainer");
        $.get(Cart._properties.getCartViewLink).done(function (result){
            container.html(result);
        }).fail(function () { console.log("error"); });
    },

    showToolTip: function () {
        button.tooltip({
            title: "Added to Cart"
        }).tooltip('show');

        setTimeout(function () { button.tooltip('destroy'); }, 500);
    }
}