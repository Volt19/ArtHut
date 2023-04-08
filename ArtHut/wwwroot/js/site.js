document.addEventListener("DOMContentLoaded", function () {
    window.addEventListener('scroll', function () {
        if (window.scrollY > 50) {
            document.getElementById('navbar_top').classList.add('fixed-top');
            navbar_height = document.querySelector('.navbar').offsetHeight;
            document.body.style.paddingTop = navbar_height + 'px';
        } else {
            document.getElementById('navbar_top').classList.remove('fixed-top');
            document.body.style.paddingTop = '0';
        }
    });
});


//let PresentationslideIndex = 1;
//PresentationSlides(PresentationslideIndex);

//function plusPresentationSlides(n) {
//    PresentationSlides(PresentationslideIndex += n);
//}

//function currentPresentationSlides(n) {
//    PresentationSlides(PresentationslideIndex = n);
//}
//function PresentationSlides(n) {
//    let i;
//    let slides = document.getElementsByClassName("MyPresentationSlides");
//    let dots = document.getElementsByClassName("Slide");
//    if (n > slides.length) { PresentationslideIndex = 1 }
//    if (n < 1) { PresentationslideIndex = slides.length }
//    for (i = 0; i < slides.length; i++) {
//        slides[i].style.display = "none";
//    }
//    for (i = 0; i < dots.length; i++) {
//        dots[i].className = dots[i].className.replace(" active", "");
//    }
//    slides[PresentationslideIndex - 1].style.display = "block";
//    dots[PresentationslideIndex - 1].className += " active";
//}