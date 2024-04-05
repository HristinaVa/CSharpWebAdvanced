// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//function FillCities(lstCountryCtrl, lstCityId) {

//    var lstCities = $("#" + lstCityId);
//    lstCities.empty();



//    var selectedCountry = lstCountryCtrl.options[lstCountryCtrl.selectedIndex].value;

//    if (selectedCountry != null && selectedCountry != '') {
//        $.getJSON("/Child/GetClassByAge", { ageId: selectedCountry }, function (cities) {
//            if (cities != null && !jQuery.isEmptyObject(cities)) {
//                $.each(cities, function (index, city) {
//                    lstCities.append($('<option/>',
//                        {
//                            value: city.value,
//                            text: city.text
//                        }));
//                });
//            };
//        });
//    }

//    return;
//}
function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7190/api/statistics', function (data) {
                $('#total_ageGroups').text(data.totalAgeGroups + " Age Groups");
                $('#total_classGroups').text(data.totalClassGroups + " Class Groups");
                $('#total_children').text(data.totalChildren + " Children");

                $('#statistics_box').removeClass('d-none');

                $('#statistics_btn').text('Hide Statistics');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-success');
            });
        } else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Show Statistics');
            $('#statistics_btn').removeClass('btn-success');
            $('#statistics_btn').addClass('btn-primary');
        }
    });
}