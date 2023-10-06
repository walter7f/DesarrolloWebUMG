<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Coffe Place</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
    <link rel="stylesheet" href="styles.css">

</head>

<body>

    <header class="header">

        <h1>Coffe's</h1>
        <a href="#" class="logo">
            <img src="imges/log.png" alt="">
        </a>
        <nav class="navbar">
            <a href="#home">Inicio</a>
            <a href="#menu">Nosotros</a>
            <a href="#menu2">Menu</a>
            <a href="#vision">Vision-Mision</a>
            <a href="#contactos">Contactos</a>
            <i class="fas fa-shopping-cart icon" style="font-size: 40px;"></i>
        </nav>

    </header>

    <section class="home" id="home">
        <div class="content">
            <h3>Inicia tu dia con un buen cafe </h3>
            <p>
                Nuestro café es cuidadosamente seleccionado para ofrecerte el mejor sabor y aroma.
                Además, nuestro ambiente es acogedor y relajante,
                ideal para tomar una pausa en medio del caos diario.
                ¡Ven conocenos no te arepentiras!
            </p>
            <a href="#menu" class="btn">Conocenos</a>
        </div>
    </section>

    <section class="menu" id="menu">
        <h1 class="heading"><span>¿Quienes</span> Somos?</h1>

        <div class="row">
            <div class="image">
                <img src="imges/item1.jpg" alt="">
            </div>
            <div class="content">
                <h3>Coffe's</h3>
                <p>
                    ¡Bienvenidos a nuestra cafetería! Somos una empresa apasionada por ofrecer la mejor calidad de café
                    y el mejor servicio a nuestros clientes. Trabajamos con granos de café de la mejor calidad,
                    cuidadosamente seleccionados para ofrecer el mejor sabor y aroma. Además,
                    nuestro personal amable y servicial está siempre dispuesto a ayudarte a encontrar la opción de café
                    perfecto para ti. Nuestro objetivo es ofrecerte una experiencia única de café que te haga querer
                    volver una y otra vez. ¡Ven a visitarnos y vive la experiencia de nuestro café!
                </p>
                <a href="#menu2" class="btn">Conoce nuestras Delicias</a>
            </div>
        </div>
    </section>
    <section class="vision" id="vision">
        <h1 class="heading"><span>Vision</span>- Mision</h1>

        <div class="row">
            <div class="image">
                <img src="imges/item1.jpg" alt="">
            </div>
            <div class="content">
                <h3>Misión</h3>
                <p>
                    En nuestra cafetería, nos dedicamos a proporcionar a nuestros clientes una experiencia
                     excepcional de café y servicio. Nuestra misión es ser el lugar favorito donde las personas puedan
                     disfrutar de momentos de tranquilidad, inspiración y socialización mientras saborean una variedad de cafés y 
                     deliciosos productos horneados.
                </p>
                <h3>Visión</h3>
                <p>
                    Nuestra visión es convertirnos en la cafetería líder 
                    en la comunidad, reconocida por la excelencia en la calidad de nuestros productos y la atención al cliente.
                     Nos esforzamos por ser un lugar donde las personas puedan conectarse, relajarse y recargar energías en un ambiente 
                     que refleje calidez y hospitalidad. 
                </p>
                <a href="#menu2" class="btn">Conoce nuestras Delicias</a>
            </div>
        </div>
    </section>


    <section class="menu2" id="menu2" onscroll="movePopup()">
        <h1 class="heading">Nuestro<span> Menu</span></h1>

        <?php
            $products = [
                ["img" => "imges/item3.jpg", "name" => "Cafe Expreso Doble", "price" =>  10.00],
                ["img" => "imges/pp1.jfif", "name" => "Cafe Expreso", "price" =>  20.00],
                ["img" => "imges/pp.2.jpg", "name" => "Cafe Late", "price" => 30.00],
                // Agregar más productos aquí
            ];
            ?>
            <div class="box-container">
                <?php foreach ($products as $product) { ?>
                    <div class="box">
                        <img src="<?php echo $product['img']; ?>" alt="">
                        <h3><?php echo $product['name']; ?></h3>
                        <div class="price"><?php echo $product['price']; ?></div>
                        <a href="#menu2" class="btn2" onclick="addItemToCart('<?php echo $product['name']; ?>',<?php echo $product['price']; ?>)">Añadir al carito <i class="fas fa-shopping-cart icon" onclick="openPopup()"></i></a>

                    </div>
                <?php } ?>
            </div>
            <div class="box-container">
   
            <?php
    // Datos de conexión a la base de datos
    $servidor = "localhost";
    $usuario = "root";
    $clave = "";
    $baseDatos = "cafe";
    
    // Crear la conexión
    $conn = new mysqli($servidor, $usuario, $clave, $baseDatos);

    // Verificar la conexión
    if ($conn->connect_error) {
        die("Conexión fallida: " . $conn->connect_error);
    }

    // Consulta SQL
    $sql = "SELECT `producto`, `precio`
            FROM `venta` WHERE 1;";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            ?>
            <div class="box">
                <h1 class="heading">Nuestros<span> Productos</span></h1>
                <h3><?php echo $row['producto'] . " " . $row['precio']; ?></h3>
               
                <!-- Agrega aquí más información que quieras mostrar -->
            </div>
            <?php
        }
    } else {
        echo "No se encontraron resultados.";
    }

    // Cerrar la conexión
    $conn->close();
    ?>
</div>


    </section>


    <section class="contactos" id="contactos">
        <h1 class="heading"> <span>contacta</span>nos</h1>
        <div class="row">
            <iframe class="map"
                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1198.7088299980321!2d-90.69329665164523!3d14.637886957148217!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x85890cbf1ff429d9%3A0xc1586b2b1e004d8!2zU2FudGEgTWFyw61hIENhdXF1w6k!5e0!3m2!1ses-419!2sgt!4v1685597787239!5m2!1ses-419!2sgt"
                width="600" allowfullscreen="" loading="lazy"></iframe>
            <div class="form_c">

                <form action="">
                    <h3>!Recerva hoy¡</h3>
                    <h4>Contactanos y recibe una orferta especial</h4>
                    <a class="wh" href="https://wa.me/34236266">
                        <img src="./imges/w.png" alt=""/>
                      </a>
            </div>

        </div>
    </section>


    </div>
    <script src="scripts.js"></script>
      <div class="popup" id="popup">
    <h2>Carrito de Compras</h2>
    <div id="cart-products">
        <!-- Los productos agregados se mostrarán aquí -->
    </div>
    <p>Total: Q <span id="total-price">0.00</span></p>
    <button onclick="simulatePayment()">Pagar</button>
    <button onclick="closePopup()">Cerrar</button>
</div>
    
      <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js"></script>
</body

</html>