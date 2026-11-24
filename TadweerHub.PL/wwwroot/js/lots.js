// ===== Lots pages =====
(function () {
  // أزرار الوزن السريعة (أقل من 1 طن / 1-5 طن / أكثر من 5 طن)
  document.querySelectorAll('.lot-pill').forEach(function (btn) {
    btn.addEventListener('click', function () {
      var min = document.getElementById('minKg');
      var max = document.getElementById('maxKg');
      if (!min || !max) return;
      min.value = btn.dataset.min || '';
      max.value = btn.dataset.max || '';
      document.querySelectorAll('.lot-pill').forEach(function (b) { b.classList.remove('active'); });
      btn.classList.add('active');
    });
  });

  // معرض الصور في صفحة التفاصيل
  var main = document.getElementById('galleryMain');
  if (main) {
    var idx = document.getElementById('galleryIdx');
    var cap = document.getElementById('galleryCaption');
    document.querySelectorAll('.thumb').forEach(function (t) {
      t.addEventListener('click', function () {
        document.querySelectorAll('.thumb').forEach(function (x) { x.classList.remove('active'); });
        t.classList.add('active');
        main.style.background = t.dataset.hex;
        main.style.opacity = getComputedStyle(t).getPropertyValue('--o') || 1;
        idx.textContent = t.dataset.idx;
        cap.textContent = 'صورة: ' + t.dataset.caption;
      });
    });
  }
})();
