# voting-system
A university proyect using C#
Un representante de un condominio lo contacta para que desarrolle un sistema de votaciones para la Presidencia del Condominio.

Este representante entrega unos lineamentos, donde el primer punto, indica que para estas elecciones existen dos candidatos, denominados “A” y “B”. Por otra parte, el reglamento presentado expresa que un voto es asignado a un apartamento, por lo que solo se permite un voto por apartamento; el voto lo ejecuta un represéntate de dicho apartamento. También precisa que el formato para ganar las elecciones es mediante la mayoría simple, por lo que un candidato gana la elección si consigue el 50% + 1 de los votos. De igual forma, revela que cualquier voto diferente a “A” y “B” se debe tomar como nulo. Finalmente, establece que la votación finaliza o termina si no existe nadie más en la cola, o si cada representante de cada apartamento ya ha votado.

El representante describe que el edificio cuenta con 2 apartamentos por piso y un total de 10 pisos. Cada apartamento tiene una identificación en el formato “PISO_APARTAMENTO”. Ejemplo: El apartamento A del piso 1, tiene como identificador “1A”; el apartamento B del piso 4, se identifica como “4B”. EL sistema para la elección debe cumplir con las siguientes condiciones:

<ul>
  <li>Evitar que un representante de un apartamento vote más de dos veces.</li>
  <li>Debe permitir auditar los resultados.</li>
</ul>

El sistema para la elección debe funcionar de la siguiente manera:
<ul>
  <li>Pregunta al votante su identificación (la identificación del apartamento)</li>
    <ul>
      <li>Si el representante no ha votado, se le permite votar, de lo contrario se prosigue con el siguiente votante.</li>
    </ul>
  <li>Luego que un representante realiza su voto, el sistema debe comprobar si existen posibles votantes (personas que aún no han votado):</li>
    <ul>
      <li>De existir posibles votantes, debe preguntar si existe votantes en la cola.</li>
        <ul>
          <li>Si existe un votante en la cola, sigue el proceso</li>
          <li>Si no existe un nuevo votante, la votación finaliza</li>
        </ul>
      <li>De no existir posible votantes, es decir, ya todos los apartamentos han votado, la votación finaliza.</li>
    </ul>
  <li>Cuando el votante ejerce su voto, se debe validar si es un candidato correcto:</li>
    <ul>
     <li>Si el candidato es correcto, se debe sumar el voto a su favor</li>
     <li>Si el candidato es incorrecto, se debe sumar como un voto nulo</li>
    </ul>
  <li>Cuando la elección finaliza, el sistema debe mostrar:</li>
    <ul>
      <li>El candidato ganador o indicar si fue empate
      <li>La cantidad de electores que se presentaron
      <li>El porcentaje de participación
      <li>La cantidad de votos para el candidato “A”
      <li>La cantidad de votos para el candidato “B”
      <li>La cantidad de votos nulos
      <li>Adicionalmente, debe ofrecer la opción para auditar los resultados.
      <li>En dicho caso, simplemente se deben mostrar cada una de los votos.
    </ul>
</ul>
