const staticCacheName = 'site-static-v1';
const isOnline = navigator.onLine;

const assets = [
    '/manifest.json',
    '/fallback.html',
    '/favicon.ico',
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
        })
    )
});

//activate service worker
self.addEventListener('activate', (evt) => {
    evt.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(keys
                .filter(key => key !== staticCacheName)
                .map(key => caches.delete(key)))
        })
    )
});

self.addEventListener('fetch', (evt) => {
    //don't cache resources from other sites

    evt.respondWith(
        caches.match(evt.request)
            .then(cacheRes => {
                return cacheRes || fetch(evt.request)
                    .then(fetchRes => {

                        //if the url is a resource, cache it
                        if (evt.request.url.includes('/Styles/')
                            || evt.request.url.includes('/Scripts/')
                            || evt.request.url.includes('/Resources/')) {

                            return caches.open(staticCacheName).then(cache => {
                                cache.put(evt.request.url, fetchRes.clone());

                                return fetchRes;
                            })
                        }

                        return fetchRes;
                    })
            })
    )
})