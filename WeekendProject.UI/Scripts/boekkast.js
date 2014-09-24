$(function () {

    var ajaxFormSubmit = function() {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function(data) {
            var $target = $($form.attr("data-boekkast-target"));
            $target.replaceWith(data);
        });
        return false;
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-boekkast-autocomplete")
        };

        $input.autocomplete(options);
    };

    $("form[data-boekkast-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-boekkast-autocomplete]").each(createAutocomplete);

});