

  var productCount = 1;

  function openPopup() {
    var popup = document.getElementById("popup");
    popup.style.display = "block";
      movePopup();
    popup.style.display = "block";
    productCount++;
      updateProductCount();
  }

  function closePopup() {
    var popup = document.getElementById("popup");
    popup.style.display = "none";
  }

  function simulatePayment() {
    alert("Pago simulado exitosamente");
    closePopup();
  }

  function removeProduct() {
    if (productCount > 0) {
      productCount--;
      document.getElementById("product-count").textContent = productCount;
    }
  }
  function updateProductCount() {
    document.getElementById("product-count").textContent = productCount;
  }

  function movePopup() {
    var popup = document.getElementById("popup");
    var popupHeight = popup.clientHeight;
    var windowHeight = window.innerHeight;
    var scrollTop = window.scrollY || document.documentElement.scrollTop;

    if (scrollTop + windowHeight >= popupHeight) {
      popup.style.top = (scrollTop + windowHeight - popupHeight) + "px";
    } else {
      popup.style.top = scrollTop + "px";
    }
  }