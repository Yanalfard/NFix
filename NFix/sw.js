const staticCacheName = 'site-static-v3';
const dynamicCacheName = 'site-dynamic-v3';
const cacheMaxSize = 3;

const assets = [
    '/',
    '/manifest.json',
    '/Scripts/app.js',
    '/Scripts/Model.js',
    '/Scripts/modal.js',
    '/Scripts/bootstrap.js',
    '/Scripts/Jquery/jquery-3.5.1.min.js',
    '/Scripts/Jquery/jquery-3.5.1.js',
    '/Scripts/Loading/Loading.js',
    '/Scripts/OwlCarousel/owl.carousel.min.js',
    '/Scripts/UIKit/uikit-icons.js',
    '/Scripts/UIKit/uikit-icons.min.js',
    '/Scripts/UIKit/uikit.js',
    '/Scripts/UIKit/uikit.min.js',
    '/Scripts/UIScripts/BMICalculator.js',
    '/Scripts/UIScripts/CommentSection.js',
    '/Scripts/UIScripts/Global.js',
    '/Scripts/UIScripts/CopyToClipboard.js',
    '/Scripts/UIScripts/ImageLoadFailed.js',
    '/Scripts/UIScripts/Index.js',
    '/Styles/about.min.css',
    '/Styles/Admin.min.css',
    '/Styles/blogs.min.css',
    '/Styles/Category.min.css',
    '/Styles/Controls.min.css',
    '/Styles/Index.min.css',
    '/Styles/Plans.min.css',
    '/Styles/Profile.min.css',
    '/Styles/Video.min.css',
    '/Styles/OwlCarousel/owl.carousel.min.css',
    '/Styles/OwlCarousel/owl.theme.default.min.css',
    '/Styles/UIKit/uikit.min.css',
    '/Resources/Png/Background.png',
    '/Resources/Png/BodyBuilding.png',
    '/Resources/Png/CalculatorBackground.png',
    '/Resources/Png/LoginImage.png',
    '/Resources/Png/Man.png',
    '/Resources/Png/Login.png',
    '/Resources/Png/Register.png',
    '/Resources/Png/Mobile/icon_512.png',
    '/Resources/Png/Mobile/icon_384.png',
    '/Resources/Png/Mobile/icon_152.png',
    '/Resources/Png/Mobile/icon_192.png',
    '/Resources/Png/Mobile/icon_144.png',
    '/Resources/Png/Mobile/icon_128.png',
    '/Resources/Png/Mobile/icon_96.png',
    '/Resources/Png/Mobile/icon_72.png',
    '/Resources/Png/Tutors/Tutor_1.jpg',
    '/Resources/Svg/NoImage.svg',
    '/Resources/Svg/3.svg',
    '/Resources/Svg/AnimatedBubble.svg',
    '/Resources/Svg/ArvinTavWhite.svg',
    '/Resources/Svg/asdfwe01.svg',
    '/Resources/Svg/asdfwe02.svg',
    '/Resources/Svg/asdfwe03.svg',
    '/Resources/Svg/asdfwe04.svg',
    '/Resources/Svg/Formula.svg',
    '/Resources/Svg/Gold.svg',
    '/Resources/Svg/NFIX.svg',
    '/Resources/Svg/NfixAnimated.svg',
    '/Resources/Svg/NFIXBlack.svg',
    '/Resources/Svg/NotFound.svg',
    '/Resources/Svg/Plat.svg',
    '/Resources/Svg/Sliver.svg',
    '/Resources/Svg/Unio2n.svg',
    '/Resources/Svg/Union.svg',
    '/Resources/Svg/Biscuits/Poly_1.svg',
    '/Resources/Svg/Biscuits/Poly_2.svg',
    '/Resources/Svg/Footer/maestro.svg',
    '/Resources/Svg/Footer/master.svg',
    '/Resources/Svg/Footer/paypal.svg',
    '/Resources/Svg/Footer/visa.svg',
    '/Resources/Svg/VID-20201104-WA0001.mp4',
    '/fallback.html',
    'https://fonts.gstatic.com/s/roboto/v18/KFOmCnqEu92Fr1Mu4mxKKTU1Kg.woff2',
    'https://fonts.gstatic.com/s/roboto/v18/KFOlCnqEu92Fr1MmEU9fBBc4AMP6lQ.woff2'
];

//install the service worker
self.addEventListener('install', (evt) => {
    evt.waitUntil(
        caches.open(staticCacheName).then(cache => {
            for (let item of assets) {
                cache.add(item);
            }
            //cache.addAll(assets);
        })
    )
});

// cache size limit 
const limitCacheSize = (name, size) => {
    caches.open(name).then(cache => {
        cache.keys().then(keys => {
            if (keys.length > size) {
                cache.delete(keys[0]).then(limitCacheSize(name, size));
            }
        })
    })
}

//activate service worker
self.addEventListener('activate', (evt) => {
    //console.log('Service worker activated');
    evt.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(keys
                .filter(key => key !== staticCacheName && key !== dynamicCacheName)
                .map(key => caches.delete(key)))
        })
    )
});

self.addEventListener('fetch', (evt) => {
    //console.log('Fetch event', evt);
    evt.respondWith(
        caches.match(evt.request).then(cacheRes => {
            if (!evt.request.url.includes('http')) return fetch(evt.request);
            return cacheRes || fetch(evt.request).then(fetchRes => {
                return caches.open(dynamicCacheName).then(cache => {
                    cache.put(evt.request.url, fetchRes.clone());
                    limitCacheSize(dynamicCacheName, cacheMaxSize);
                    return fetchRes;
                })
            }).catch(() => {
                if (evt.request.url.includes('/Home/') || evt.request.url.includes('/View/'))
                    return caches.match('/fallback.html')
            });
        })
    )
})