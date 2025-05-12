//Létrehozunk Vue objektumokat a tulajdonságok hatékonyabb kezelése végett:
const vue = new Vue({ //Egy új 'Vue' típusú objektum 'vue' néven
  el: '.preloader', //a 'preloader' elemet akarom kezelni a Vue objektum által
  //Itt pedig megadom, hogy milyen tulajdonságokat/státuszokat akarok kezelni:
  data: { //(az oldal egy betöltési csíkot visz végig, annak a tulajdonságait/státuszait kezeljük)
    loaded: 0,
    loading: null,
    loadStyle: {
      width: '0%' },

    statusElem: $('[status]'),
    loader: $('[loader]'),
    body: $('body') },
//Ez itt egy összetett szótártömb volt, értékpárokkal
  ready() {
    this.preloader = $(this.$el);
    this.removeScrolling();
    this.startLoading();
	//this = az aktuálisan kezelt objektumra mutat
  },
  watch: {
    loaded() {
      this.loadStyle.width = `${this.loaded}%`;//Változók behivatkozása: ${VáltozóNeve}
    } }, //Az AltGr+7 féle `` jelek a HTML tartalom jelölésére valók.

  methods: {
    removeScrolling() {
      this.body.css('overflow', 'hidden');
    },
    startLoading() {
      this.loading = setInterval(this.load, 20); //időzítés: setInterval(MiTörténjen,HányEzredMpként);
    },
    load() {
      this.loaded < 100 ? this.loaded++ : this.doneLoading();
	  //Alternatív if-else: (LogikaiÁllítás) ? MűveletHaTeljesül : MűveletHaNemTeljesül;
    },
    doneLoading() {
      clearInterval(this.loading); //Időzített ismétlődés levétele az objektumról
      this.updateStatus();
    },
    updateStatus() {
      this.statusElem.text('Meg is lennénk!');
      this.loader.fadeOut();
      this.animatePreloader();
    },
    animatePreloader() {
      let app = this,
      height = this.preloader.height(),
      properties = { //Css tulajdonság beállítása
        'margin-top': `-${height}` },
      options = {
        duration: 1000, //Minden idő érték (pl itt az 1000-res szám) az ezredmáspdperc értéket jelöl
        easing: 'swing',
        complete() {
          app.removePreloader();
        } };

      this.preloader.delay(500).animate(properties, options); //Fél másodperces késleltetés
    },
    removePreloader() {
      this.preloader.remove();
      this.body.removeAttr('style');
      this.animateWebsite();
    },
    animateWebsite() {
      console.log('jól van'); //Mögöttes ellenőrzés a teszteléshez
    } } });