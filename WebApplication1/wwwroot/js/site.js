// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification


//// פונקציה שתבצע בקשת Ajax
//$('.post-title').on('click', function (e) {
//    e.preventDefault();
//    var title = e.target.innerText;
//    $.ajax({
//        url: '/Home/DetailsNews?title=' + encodeURIComponent(title), // שימי לב להוסיף את '/Home'
//        type: 'GET',
//        success: function (data) {
//            alert('Title: ' + data.title + '\nBody: ' + data.body + '\nLink: ' + data.link);
//        },
//        error: function (err) {
//            console.log(err);
//            alert('אפשר לנסות מאוחר יותר');
//        }
//    });
//});

//$('.post-title').on('click', function (e) {
//    e.preventDefault();
//    var title = e.target.innerText;
//    $.ajax({
//        url: 'HomeController/Details?title=' + encodeURIComponent(title),
//        type: 'GET',
//        success: function (data) {
//            alert('Title: ' + data.title + '\nBody: ' + data.body + '\nLink: ' + data.link);

//        },
//        error: function (err) {
//            console.log(err);
//            alert('אפשר לנסות מאוחר יותר');
//        }
//    });
//});

