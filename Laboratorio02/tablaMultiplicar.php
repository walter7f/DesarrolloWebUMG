<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Tabla de Multiplicar</title>
  </head>
 <style>
  .box{
    dispay: inline-block;
  }
 </style>

  <body>
    <div lign="center" class="box">


    <div align="center">
      <!-- Se crea un formulario y se envía por método POST -->
      <form name="tb" action="tablaMultiplicar.php" method="post">
        <P align="center">
          <!-- Se crea una lista desplegable con los números del 1 al 10 -->
          Seleccione una opción: 
          <select align="center" name="tabNumber">
          <?php
            for ($k = 1; $k <= 10; $k++) {
              if ($k == 5) {
                echo "<option selected>" . $k . "</option>";
              } else {
                echo "<option>" . $k . "</option>";
              }
            }
          ?>
          </select>
          <br />
          <!-- Botón para enviar el formulario -->
          <input type="submit" value="Ver Tabla" name="submitTabla" />
        </P>
      </form>
    
      <?php
        $i = 0;
        $showTable = isset($_POST['tabNumber']) && $_POST['tabNumber'] !== "";

        if ($showTable) {
          $i = $_POST['tabNumber'];
        }
      ?>
      <br /><br />
      <table border="1" cellpadding="3" cellspacing="0">
      <?php
        if ($showTable) {
          echo "<thead><tr><th colspan='5'>Tabla del " . $i . "</th></tr><thead>";
        }

        if ($showTable) {
          for ($a = 1; $a <= 10; $a++) {
            echo "<tr>";
            echo "<td>" . $i . "</td> <td>x</td> <td>" . $a . "</td> <td>=</td> <th>" . ($i * $a) . "</th>";
            echo "</tr>";
          }
        }
      ?>
    </table>
    </div>



<!-- calculadora -->

    <div align="center">
      <!-- Se crea un formulario y se envía por método POST -->
      <form name="tb" action="tablaMultiplicar.php" method="post" >
        <P align="center">
        Numero_1: 
        <input name="numero1" type="number"></input> 
          </select>

          Operador: 
          <select align="center" name="operador">
              <option name="+" value="+" >+</option>
              <option name="-" value="-" >-</option>
              <option name="*" value="*" >*</option>
              <option name="/" value="/" >/</option>

          </select>

          Numero_2: 
          <input name="numero2" type="number"></input> 
          <br />
          <br />
          <!-- Botón para enviar el formulario -->
          <input type="submit" value="Operar" name="submitTabla" />
        </P>
      </form>
    
      <?php
        $oper = "";
        $i= 0;
        $j=0;
        $showTable1 = isset($_POST['numero1']) && $_POST['numero1'] !== "";
        $showTable2 = isset($_POST['numero2']) && $_POST['numero2'] !== "";
        $operadors= isset($_POST['operador']) && $_POST['operador'] !== "";

        if ($showTable1) {
          $i = $_POST['numero1'];
        }
        if ($showTable2) {
          $j = $_POST['numero2'];
        }
        if ($operadors) {
          $oper = $_POST['operador'];
        }
        
      ?>
      <br /><br />
      <table border="1" cellpadding="3" cellspacing="0">
      <?php
          echo "<thead><tr><th colspan='5'>Operador " .$oper. "</th></tr><thead>";


          if ($showTable1) {
           if($oper=="+"){
              echo "<tr>";
              echo "<td>" . $i . "</td> <td>+</td> <td> $j </td> <td>Suma: " . $oper . "</td> <td>=</td> <th>" . ($i + $j) . "</th>";
              echo "</tr>"; 
            } else if($oper=="-"){
              echo "<tr>";
              echo "<td>" . $i . "</td> <td>-</td> <td> $j </td> <td>Resta: " . $oper . "</td> <td>=</td> <th>" . ($i - $j) . "</th>";
              echo "</tr>"; 
            }else if($oper=="*"){
              echo "<tr>";
              echo "<td>" . $i . "</td> <td>*</td> <td> $j </td> <td>Multiplicacion: " . $oper . "</td> <td>=</td> <th>" . ($i * $j) . "</th>";
              echo "</tr>"; 
            }else{echo "<tr>";
              echo "<td>" . $i . "</td> <td>/</td> <td> $j </td> <td>Division: " . $oper . "</td> <td>=</td> <th>" . ($i / $j) . "</th>";
              echo "</tr>"; 
            }
          }

      ?>

    </table>
    </div>


    </div>
  </body>
</html>

