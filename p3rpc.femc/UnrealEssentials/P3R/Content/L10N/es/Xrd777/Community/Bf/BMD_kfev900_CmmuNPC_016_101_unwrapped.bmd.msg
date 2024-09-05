[msg MSG_000_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 3 1 3 0 65535 20302 0 0][uf 5 21 1 160]¿Eh? ¿De verdad le has tomado nota a todo el mundo?[n][uf 1 1][e]

[sel SEL_001_0_0 top]
[uf 0 5 65278][uf 2 1]Sin duda.[e]
[uf 0 5 65278][uf 2 1]Todavía no.[e]

[msg MSG_002_0_0 [Camarero]]

[msg MSG_003_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 3 1 3 0 65535 20305 0 0][uf 5 21 1 160]Bueno, no pasa nada. No te puedo obligar.[n][uf 1 1][e]

[sel SEL_004_0_0 top]
[uf 0 5 65278][uf 2 1]Un martini de manzana[e]
[uf 0 5 65278][uf 2 1]Un Bloody Mary[uf 2 9 1 1 647][e]
[uf 0 5 65278][uf 2 1]Un té oolong[e]
[uf 0 5 65278][uf 2 1]Un margarita[e]

[msg MSG_005_0_0 [Camarero]]

[sel SEL_006_0_0 top]
[uf 0 5 65278][uf 2 1]Una cerveza negra[e]
[uf 0 5 65278][uf 2 1]Un Bloody Mary[e]
[uf 0 5 65278][uf 2 1]Un destornillador[e]
[uf 0 5 65278][uf 2 1]Un margarita[uf 2 9 1 1 647][e]

[msg MSG_007_0_0 [Camarero]]

[sel SEL_008_0_0 top]
[uf 0 5 65278][uf 2 1]Un martini de manzana[e]
[uf 0 5 65278][uf 2 1]Un destornillador[uf 2 9 1 1 647][e]
[uf 0 5 65278][uf 2 1]Un margarita[e]
[uf 0 5 65278][uf 2 1]Un té oolong[e]

[msg MSG_009_0_0 [Camarero]]

[sel SEL_010_0_0 top]
[uf 0 5 65278][uf 2 1]Un ginger ale[e]
[uf 0 5 65278][uf 2 1]Un destornillador[e]
[uf 0 5 65278][uf 2 1]Un margarita[e]
[uf 0 5 65278][uf 2 1]Un té oolong[uf 2 9 1 1 647][e]

[msg MSG_011_0_0 [Camarero]]

[msg MSG_013_0_0 [Camarero]]

[msg MSG_012_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 3 1 3 0 65535 20303 0 0][uf 5 21 1 160]Oye, ¿qué era lo que querías?[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 5 21 1 160]Ah, sí. Una copa para el monje de arriba. Seguro que quiere coñac otra vez.[n][uf 1 1][e]

[msg MSG_014_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 3 1 3 0 65535 20305 0 0][uf 5 21 1 160]Está bien. No pareces mala niña, así que le serviré una copa.[n][uf 1 1][e]

[msg MND_015_0_0]
[uf 0 5 65278][uf 2 1]Parece que me he ganado su confianza. Ahora seré capaz de hablar con el monje.[n][uf 1 1][e]

[msg MSG_016_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 5 21 1 160]Dile que ya mismo se la sirvo.[n][uf 1 1][e]

[sel SEL_017_0_0 top]
[uf 0 5 65278][uf 2 1]Muy bien.[e]
[uf 0 5 65278][uf 2 1]Un momento.[e]

[msg MSG_018_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 3 1 3 0 65535 20303 0 0][uf 5 21 1 160]Hasta luego.[n][uf 1 1][e]

[msg MSG_019_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 3 1 3 0 65535 20304 0 0][uf 5 21 1 160]Ah, vale. Avísame cuando tenga claro lo que quiera pedir.[n][uf 1 1][e]

[msg MSG_020_0_0 [Camarero]]
[uf 0 5 65278][uf 2 1][uf 3 1 3 0 65535 20302 0 0][uf 5 21 1 160]Buenas, ¿qué te pong...? Anda, si eres tú.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 5 21 1 160]El monje no ha venido hoy. No suele venir de lunes a miércoles.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 5 21 1 160]Estará ocupado atendiendo el templo o algo.[n][uf 1 1][e]

[msg MND_GENERAL_EVENTPLAY]
[uf 0 5 65278][uf 2 1]Mensaje enviado por el guion. Repetición del evento del comité.[n][uf 1 1][e]

[msg MND_GENERAL_PERSPNA]
[uf 0 5 65278][uf 2 1]Siento que podemos estrechar lazos gracias a la Persona del arcano [uf 2 4 2], [uf 0 1 35][uf 2 4 5][uf 0 1 27].[n][uf 1 1][e]

[msg MND_GENERALSELECTMSG_MAX]
[uf 0 5 65278][uf 2 1]Siento un vínculo irrompible con [uf 2 4 0]...[n][uf 1 1][e]

[msg MND_GENERALMSG_BS_MAX]
[uf 0 5 65278][uf 2 1]Siento un vínculo irrompible con la pareja de ancianos...[n][uf 1 1][e]

[msg MND_GENERALSELECTMSG_RAN]
[uf 0 5 65278][uf 2 1]Creo que mi relación con [uf 2 4 0] se estrechará pronto.[n][uf 1 1][e]

[msg MND_GENERALMSG_BS_RANKUP]
[uf 0 5 65278][uf 2 1]Creo que mi relación con la pareja de ancianos se estrechará pronto.[n][uf 1 1][e]

[msg MND_GENERALSELECTMSG_NOR]
[uf 0 5 65278][uf 2 1]No creo que mi vínculo con [uf 2 4 0] se fortalezca más aunque pasemos tiempo juntos...[n][uf 1 1][e]

[msg MND_GENERALMSG_BS_NORMAL [Camarero]]
[uf 0 5 65278][uf 2 1]No creo que nuestro vínculo se fortalezca más aunque pasemos tiempo juntos.[n][uf 1 1][e]

[msg MND_GENERALSELECTMSG_MAX_2]
[uf 0 5 65278][uf 2 1]Parece que tu relación no puede avanzar más...[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1]¿Deberíamos pasar el rato juntos igualmente?[n][uf 1 1][e]

[msg MND_GENERAL_MSG_SOLO_AS]
[uf 0 5 65278][uf 2 1]¿Paso un rato con [uf 2 4 0] después de clase?[n][uf 1 1][e]

[msg MND_GENERAL_MSG_SOLO_DT]
[uf 0 5 65278][uf 2 1]¿Debería pasar el día con [uf 2 4 0]?[n][uf 1 1][e]

[msg MND__GENERAL_MSG_NET]
[uf 0 5 65278][uf 2 1]¿Debería pasar tiempo en línea jugando al MMORPG con [uf 2 4 0]?[n][uf 1 1][e]

[msg MND_GENERAL_MSG_SOLO_NT]
[uf 0 5 65278][uf 2 1]¿Debería pasar la tarde con [uf 2 4 0]...?[n][uf 1 1][e]

[sel SEL_GENERALSELECTMSG_SOL top]
[uf 0 5 65278][uf 2 1]Pasar tiempo con [uf 2 4 0][e]
[uf 0 5 65278][uf 2 1]Comprobar vínculo social[e]
[uf 0 5 65278][uf 2 1]Da igual[e]

[msg MND_GENERAL_MSG_MULTIPLE]
[uf 0 5 65278][uf 2 1]¿Paso un rato en [uf 2 4 1] después de clase?[n][uf 1 1][e]

[msg MND_GENERAL_MSG_FASHION_]
[uf 0 5 65278][uf 2 1]¿Paso un rato en el club de moda después de clase?[n][uf 1 1][e]

[msg MND_GENERAL_MSG_BOOKSTOR]
[uf 0 5 65278][uf 2 1]¿Debería pasar el día en la librería?[n][uf 1 1][e]

[msg MND_GENERAL_MSG_BOOKSTOR_2]
[uf 0 5 65278][uf 2 1]¿Paso un rato en la librería después de clase?[n][uf 1 1][e]

[msg MND_GENERAL_MSG_MULTIPLE_2]
[uf 0 5 65278][uf 2 1]¿Debería pasar tiempo con [uf 2 4 1] esta noche...?[n][uf 1 1][e]

[sel SEL_GENERALSELECTMSG_MUL top]
[uf 0 5 65278][uf 2 1]Pasar un rato: [uf 2 4 1][e]
[uf 0 5 65278][uf 2 1]Comprobar vínculo social[e]
[uf 0 5 65278][uf 2 1]Da igual[e]

[sel SEL_GENERALSELECTMSG_FCL top]
[uf 0 5 65278][uf 2 1]Ir al club de moda.[e]
[uf 0 5 65278][uf 2 1]Comprobar vínculo social[e]
[uf 0 5 65278][uf 2 1]Da igual[e]

[sel SEL_GENERALSELECTMSG_BS top]
[uf 0 5 65278][uf 2 1]Entrar en la librería[e]
[uf 0 5 65278][uf 2 1]Comprobar vínculo social[e]
[uf 0 5 65278][uf 2 1]Da igual[e]

[msg MSG_GENERAL_EXAMREWARD_0 [Mitsuru Kirijo]]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0][uf 3 1 3 0 65535 4029 0 0]Ah.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]He visto tus notas. Buen trabajo.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]Toma, de parte del director.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 1 65535 65535 0 0][uf 3 1 3 0 65535 4108 0 0]Es tu recompensa por ser capaz de compaginar los estudios y nuestras... en fin, "actividades extraescolares".[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_0]
[uf 0 5 65278][uf 2 1]DEV: UNUSED LABEL[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_0_2]
[uf 0 5 65278][uf 2 1]Como he sacado la nota más alta en los exámenes, he obtenido: [uf 4 4 1 37 1 3].[n][uf 1 1][e]

[msg MSG_GENERAL_EXAMREWARD_0_2 [Mitsuru Kirijo]]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0][uf 3 1 3 0 65535 4029 0 0]Ah.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]He visto tus notas. Buen trabajo.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]Toma, de parte del director.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 1 65535 65535 0 0][uf 3 1 3 0 65535 4108 0 0]Es tu recompensa por ser capaz de compaginar los estudios y nuestras... en fin, "actividades extraescolares".[n][uf 1 1][e]

[msg MSG_GENERAL_EXAMREWARD_0_3 [Mitsuru Kirijo]]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0][uf 3 1 3 0 65535 4077 0 0]Ah, cierto. Hay algo más.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]He visto tus notas. Buen trabajo.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]Toma, de parte del director.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 1 65535 65535 0 0][uf 3 1 3 0 65535 4131 0 0]Es tu recompensa por ser capaz de compaginar los estudios y nuestras... en fin, "actividades extraescolares".[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_0_3]
[uf 0 5 65278][uf 2 1]Como he sacado la nota más alta en los exámenes, he obtenido: [uf 4 4 1 37 1 3].[n][uf 1 1][e]

[msg MSG_GENERAL_EXAMREWARD_0_4 [Mitsuru Kirijo]]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0][uf 3 1 3 0 65535 4029 0 0]Ah.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]He visto tus notas. Buen trabajo.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]Toma, de parte del director.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 1 65535 65535 0 0][uf 3 1 3 0 65535 4108 0 0]Es tu recompensa por ser capaz de compaginar los estudios y nuestras... en fin, "actividades extraescolares".[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_0_4]
[uf 0 5 65278][uf 2 1]DEV: UNUSED LABEL[n][uf 1 1][e]

[msg MSG_GENERAL_EXAMREWARD_0_5 [Mitsuru Kirijo]]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0][uf 3 1 3 0 65535 4029 0 0]Ah.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]He visto tus notas... Buen trabajo.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]Es laudable que continúes destacando en el instituto mientras libras arduos combates.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 1 65535 65535 0 0]Acepta este regalo para agradecerte tus esfuerzos.[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_0_5]
[uf 0 5 65278][uf 2 1]未使用ラベルです。[n][uf 1 1][e]

[msg MSG_GENERAL_EXAMREWARD_0_6 [Mitsuru Kirijo]]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 6 65535 0 0][uf 3 1 3 0 65535 4029 0 0]Ah.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 6 65535 0 0]He visto tus notas. Buen trabajo.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 6 65535 0 0]Es laudable que continúes destacando en el instituto mientras libras arduos combates.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 6 65535 0 0]Acepta este regalo para agradecerte tus esfuerzos.[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_1]
[uf 0 5 65278][uf 2 1]Como he sacado la nota más alta en los exámenes, he obtenido: [uf 4 4 1 37 1 3].[n][uf 1 1][e]

[msg MSG_GENERAL_EXAMREWARD_1 [Mitsuru Kirijo]]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0][uf 3 1 3 0 65535 4029 0 0]Ah.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]He visto tus notas. Buen trabajo.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 0 65535 65535 0 0]Es laudable que continúes destacando en el instituto mientras libras arduos combates.[n][uf 1 1][e]
[uf 0 5 65278][uf 2 1][uf 4 5 5 1 65535 65535 0 0][uf 3 1 3 0 65535 4108 0 0]Acepta este regalo para agradecerte tus esfuerzos.[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_1_2]
[uf 0 5 65278][uf 2 1]DEV: UNUSED LABEL[n][uf 1 1][e]

[msg MND_GENERAL_EXAMREWARD_1_3]
[uf 0 5 65278][uf 2 1]Como he sacado la nota más alta en los exámenes, he obtenido: [uf 4 4 1 37 1 3].[n][uf 1 1][e]

