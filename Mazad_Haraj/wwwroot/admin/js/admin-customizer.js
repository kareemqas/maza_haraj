// RTl & Ltr
$('<div class="btn-light custom-theme">RTL</div>').appendTo($('body'));
(function () {
})();
//live customizer js
$(document).ready(function () {
    $('.custom-theme').on('click', function () {
        $("html").attr("dir", ""); // تأكد من إزالة القيمة الموجودة هنا
        $(this).toggleClass('ltr'); // تغيير ltr بدلاً من rtl
        if ($('.custom-theme').hasClass('ltr')) {
            $('.custom-theme').text('RTL'); // تغيير RTL بدلاً من LTR
            $('body').addClass('ltr'); // تغيير rtl بدلاً من ltr
            $("html").attr("dir", "rtl"); // تغيير rtl بدلاً من ltr
        } else {
            $('.custom-theme').text('LTR'); // تغيير LTR بدلاً من RTL
            $('body').removeClass('ltr'); // تغيير ltr بدلاً من rtl
            $("html").attr("dir", ""); // تغيير ltr بدلاً من rtl
        }
    });
});
