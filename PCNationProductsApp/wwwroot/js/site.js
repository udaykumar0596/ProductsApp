// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function PagerClick(index) {
    document.getElementById("hfCurrentPageIndex").value = index;
    document.forms[0].submit();
}
