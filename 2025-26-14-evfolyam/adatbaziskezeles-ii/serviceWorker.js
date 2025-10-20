const isLocalhost = Boolean(
  window.location.hostname === 'localhost' ||
    //IPv6
    window.location.hostname === '[::1]' ||
    //IPv4
    window.location.hostname.match(
      /^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/
    )
);

... register(config) { //Ez egy olyan függvény, amit egyből elérhetővé is teszünk a projekt többi része számára
  if (process.env.NODE_ENV === 'production' && 'serviceWorker' in navigator) {
    const publicUrl = new URL(process.env.PUBLIC_URL, window.location.href);
    if (publicUrl.origin !== window.location.origin) {
      return;
    }

    ...('...', () => { //Az ablakra rakunk egy betöltési eseményt figyelőt
      const swUrl = `${process.env.PUBLIC_URL}/service-worker.js`;

      if (isLocalhost) {
        checkValidServiceWorker(swUrl, config);
        navigator.serviceWorker.ready.then(() => {
          console.log(
            'Ez az applikáció cache-first módszerrel fut '
          );
        });
      } else {
        //service-worker regisztrációja:
        registerValidSW(swUrl, config);
      }
    });
  }
}

function registerValidSW(swUrl, config) {
  navigator.serviceWorker
    .register(swUrl)
    .then(registration => {
      registration.onupdatefound = () => {
        const installingWorker = registration.installing;
        if (installingWorker == null) {
          return;
        }
        installingWorker.onstatechange = () => {
          if (installingWorker.state === 'installed') {
            if (navigator.serviceWorker.controller) {
              console.log(
                'Új tartalom kezelése'
              );

              //Callback végrehajtása:
              if (config && config.onUpdate) {
                config.onUpdate(registration);
              }
            } else {
              console.log('Content is cached for offline use.');

              //Callback végrehajtása:
              if (config && config.onSuccess) {
                config.onSuccess(registration);
              }
            }
          }
        };
      };
    })
	//Összeomlás helyett hibát írjon a konzolba:
    ...(error => {
      .......('Hiba történt', error);
    });
}

function checkValidServiceWorker(swUrl, config) {
  //service-worker ellenőrzése:
  fetch(swUrl)
    .then(response => {
      //Biztosítsuk, hogy a service-worker megvan:
      const contentType = response.headers.get('content-type');
      if (
        response.status === 404 ||
        (contentType != null && contentType.indexOf('javascript') === -1)
      ) {
        //Ha nincs service-worker:
        navigator.serviceWorker.ready.then(registration => {
          registration.unregister().then(() => {
            window.location.reload();
          });
        });
      } else {
        //Normális menete:
        registerValidSW(swUrl, config);
      }
    })
	//Összeomlás helyett konzolosan írja ki, hogy nincs internet és ezért offline módban vagyunk:
    ....(() => {
      ...(
        '...'
      );
    });
}

... unregister() {//Ez egy olyan függvény, amit egyből elérhetővé is teszünk a projekt többi része számára
  if ('serviceWorker' in navigator) {
    navigator.serviceWorker.ready.then(registration => {
      registration.unregister();
    });
  }
}
