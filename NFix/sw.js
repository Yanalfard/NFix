const staticCacheName = 'site-static';

const assets = [
    '/',
    '/Scripts/app.js',

];

//const assets = [
//    '/',
//    '/index.cshtml',
//    '/Scripts/app.js',
//    '/Scripts/Model.js',
//    '/Scripts/modal.js',
//    '/Scripts/bootstrap.js',
//    '/Scripts/Jquery/jquery-3.5.1.min.js',
//    '/Scripts/Jquery/jquery-3.5.1.js',
//    '/Scripts/Loading/Loading.js',
//    '/Scripts/OwlCarousel/owl.carousel.min.js',
//    '/Scripts/UIKit/uikit-icons.js',
//    '/Scripts/UIKit/uikit-icons.min.js',
//    '/Scripts/UIKit/uikit.js',
//    '/Scripts/UIKit/uikit.min.js',
//    '/Scripts/UIScripts/BMICalculator.js',
//    '/Scripts/UIScripts/CommentSection.js',
//    '/Scripts/UIScripts/Global.js',
//    '/Styles/about.min.css',
//    '/Styles/Admin.min.css',
//    '/Styles/blogs.min.css',
//    '/Styles/Category.min.css',
//    '/Styles/Controls.min.css',
//    '/Styles/Index.min.css',
//    '/Styles/Plans.min.css',
//    '/Styles/Profile.min.css',
//    '/Styles/Video.min.css',
//    '/Styles/owl.carousel.min.css',
//    '/Styles/owl.theme.default.min.css',
//    '/Styles/uikit.min.css',
//    '/Resources/Png/Background.png',
//    '/Resources/Png/BodyBuilding.png',
//    '/Resources/Png/CalculatorBackground.png',
//    '/Resources/Png/LoginImage.png',
//    '/Resources/Png/Man.png',
//    '/Resources/Png/Mobile/Man.png',
//    '/Resources/Png/Mobile/icon_512.png',
//    '/Resources/Png/Mobile/icon_384.png',
//    '/Resources/Png/Mobile/icon_152.png',
//    '/Resources/Png/Mobile/icon_192.png',
//    '/Resources/Png/Mobile/icon_144.png',
//    '/Resources/Png/Mobile/icon_128.png',
//    '/Resources/Png/Mobile/icon_72.png',
//    '/Resources/Png/Mobile/icon_96.png',
//    '/Resources/Png/Mobile/icon_96.png',
//    '/Resources/Svg/3.svg',
//    '/Resources/Svg/AnimatedBubble.svg',
//    '/Resources/Svg/ArvinTavWhite.svg',
//    '/Resources/Svg/asdfwe01.svg',
//    '/Resources/Svg/asdfwe02.svg',
//    '/Resources/Svg/asdfwe03.svg',
//    '/Resources/Svg/asdfwe04.svg',
//    '/Resources/Svg/Formula.svg',
//    '/Resources/Svg/Gold.svg',
//    '/Resources/Svg/NFIX.svg',
//    '/Resources/Svg/NfixAnimated.svg',
//    '/Resources/Svg/NFIXBlack.svg',
//    '/Resources/Svg/NotFound.svg',
//    '/Resources/Svg/Plat.svg',
//    '/Resources/Svg/Silver.svg',
//    '/Resources/Svg/Unio2n.svg',
//    '/Resources/Svg/Union.svg',
//    '/Resources/Svg/Biscuits/Poly_1.svg',
//    '/Resources/Svg/Biscuits/Poly_2.svg'
//];



//install the service worker
self.addEventListener('install', (evt) => {
    //console.log('Service worker installed');
    //evt.waitUntill(
    //    caches.open(staticCacheName).then(cache => {
    //        console.log('caching shell assets');
    //        cache.addAll(assets);
    //    })
    //);
    caches.open(staticCacheName).then(cache => {
        console.log('caching shell assets');
        cache.addAll(assets);
    })
});

//activate service worker
self.addEventListener('activate', (evt) => {
    //console.log('Service worker activated');
});

self.addEventListener("fetch", (evt) => {
    console.log('Fetch event', evt);
})