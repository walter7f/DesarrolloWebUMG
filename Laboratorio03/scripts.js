

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
    var section = document.querySelector("section"); // Selecciona tu etiqueta <section>
    
    var popupHeight = popup.clientHeight;
    var sectionHeight = section.clientHeight; // Altura de la etiqueta <section>
    var scrollTop = window.scrollY || document.documentElement.scrollTop;

    if (scrollTop + sectionHeight >= popupHeight) {
        popup.style.top = (scrollTop + sectionHeight - popupHeight) + "px";
    } else {
        popup.style.top = scrollTop + "px";
    }
}



  function validar() {
// Obtener los valores del formulario
var nombre = document.formularios.myname.value;
var correo = document.formularios.mail.value;
var telefono = document.formularios.phone.value;
var contrasena = document.formularios.pass.value;

// Crear un objeto con los datos del usuario
if (nombre !== "" && correo !== "" && telefono !== "" && contrasena !== "") {
  var usuario = {
    nombre: nombre,
    correo: correo,
    telefono: telefono,
    contrasena: contrasena
  };

  localStorage.setItem('usuario', JSON.stringify(usuario));
  window.location.href = "index_php.php";
} else {
  alert("Por favor completa todos los campos.");
}
}

let cartProducts = [];
let totalPrice = 0;

function addToCart(name, price) {
    cartProducts.push({ name, price });
    totalPrice += price;
    updateCartUI();
}

function updateCartUI() {
    const cartProductsDiv = document.getElementById("cart-products");
    const totalSpan = document.getElementById("total-price");
    cartProductsDiv.innerHTML = "";

    cartProducts.forEach(product => {
        const productDiv = document.createElement("div");
        productDiv.classList.add("product");
        productDiv.innerHTML = `
            <p>Artículo: ${product.name}</p>
            <div>
                <i class="fas fa-minus-circle delete-icon" onclick="removeProduct('${product.name}', ${product.price})"></i>
                <span>1</span> unidad
            </div>
        `;
        cartProductsDiv.appendChild(productDiv);
    });

    totalSpan.textContent = totalPrice.toFixed(2);
}

function removeProduct(name, price) {
    const index = cartProducts.findIndex(product => product.name === name);
    if (index !== -1) {
        cartProducts.splice(index, 1);
        totalPrice -= price;
        updateCartUI();
    }
}

// Llamar a esta función cuando se presione el botón "Añadir al carito"
function addItemToCart(name, price) {
    addToCart(name, price);
    updateCartUI();
    openPopup(); // Abre el popup para mostrar los cambios
}
