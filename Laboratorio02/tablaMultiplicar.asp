<%@ Language=VBScript %>
<html>
  <head>
    <meta charset="utf-8">
    <title>Tabla de Multiplicar</title>
  </head>
  <body>
    <div align="center">

      <form name="tb" action="tablaMultiplicar.asp" method="post">
        <P align="s">
          <!- Se crea una lista desplegable con los numeros del 1 al 10 ->
          Seleccione una opción: 
          <select align="center" name="tabNumber">
          <%
            for k = 1 to 10
              if k = 5 then
                Response.Write "<option selected>" & k & "</option>"
              else
                Response.Write "<option>" & k & "</option>"
              end if
            next
          %>
          </select>
          <br />
          <!- Boton para enviar el formulario ->
          <input type="submit" value="Ver Tabla" name="submitTabla" />
        </P>
      </form>
    
      <%
        Dim i
        Dim showTable
    
        'Verificar si se enviaron datos del formulario
        showTable = request.form("tabNumber") <> ""
        if showTable then
          'Se toma el dato recibido en el formulario
          i = Request.Form("tabNumber")
        else
          'Inicializa la tabla en cero
          i = 0
        end if
      %>
      <br /><br />
      <table border="1" cellpadding="3" cellspacing="0">
      <%
        'Mostrar la tabla del número que recibe  del formulario
        if showTable then
          Response.Write "<thead><tr><th colspan='5'>Tabla del " & i & "</th></tr><thead>"
        end if

        'Ciclo del 1 al 10 para mostrar la tabla
        if showTable then
          for a=1 to 10
            Response.Write "<tr>"
            Response.Write "<td>" & i &"</td> <td>x</td> <td>" & a & "</td> <td>=</td> <th>" & i*a & "</th>"
            Response.Write "</tr>"
          next
        end if
      %>
    </table>
    </div>



    <div align="center">
    <form name="calculator" method="post">
      <p align="center">
        Numero 1:
        <input type="number" name="num1">
        Operador:
        <select name="operator">
          <option value="+">Suma</option>
          <option value="-">Resta</option>
          <option value="*">Multiplicación</option>
          <option value="/">División</option>
        </select>
        Numero 2:
        <input type="number" name="num2">
        <br>
        <input type="submit" value="Calcular" name="submitCalc">
      </p>
    </form>

    <%
      Dim num1, num2, result
      Dim operator
      num1 = CDbl(Request.Form("num1"))
      num2 = CDbl(Request.Form("num2"))
      operator = Request.Form("operator")
      result = 0

      
      If num1 <> 0 And num2 <> 0 Then
        Select Case operator
          Case "+"
            result = num1 + num2
          Case "-"
            result = num1 - num2
          Case "*"
            result = num1 * num2
          Case "/"
            If num2 <> 0 Then
              result = num1 / num2
            Else
              Response.Write "Error: División por cero."
            End If
          Case Else
            Response.Write "Operador no válido."
        End Select
      End If
    %>

    <% If result <> 0 Then %>
      <p align="center">
        El resultado de <%= num1 %> <%= operator %> <%= num2 %> es <%= result %>
        
      </p>
    <% End If %>

  </div>
  </body>
</html>