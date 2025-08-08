[sel SEL_YESNO top]
[f 2 1]Sí[e]
[f 2 1]No[e]

[sel SEL_ORDER top]
[f 2 1]Usar la habilidad de Fuuka[e]
[f 2 1]Comprobar la situación actual[e]
[f 2 1]Da igual[e]

[sel FSS_FUKA_ORDER top]
[f 2 1][f 2 4 6] / [f 2 4 7] PE[e]
[f 2 1][f 2 4 8] / [f 2 4 9] PE[e]
[f 2 1][f 2 4 10] / [f 2 4 11] PE[e]
[f 2 1][f 2 4 12] / [f 2 4 13] PE[e]
[f 2 1][f 2 4 14] / [f 2 4 15] PE[e]
[f 2 1]¿Qué ocurre?[e]

[sel SEL_FUKA_YESNO top]
[f 2 1]Estaría genial.[e]
[f 2 1]Un momento.[e]

[msg MSG_MITSURU_RETURN_ADVIC [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Es demasiado peligroso ir sola. Vuelve y elige a otros compañeros para que te ayuden en la batalla.[n][w][e]

[msg MSG_FUKA_RETURN_ADVICE [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]No es seguro ir sola. ¡Vuelve para formar un grupo![n][w][e]

[msg MSG_MITSURU_NOT_ORDER_BT [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Podría pasar cualquier cosa. Será mejor no bajar la guardia.[n][w][e]

[msg MSG_FUKA_NOT_ORDER_BTL [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]No bajéis la guardia y preparaos para cualquier cosa.[n][w][e]

[msg MSG_MITSURU_NOT_ORDER_NO [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4085 0 0]No detecto enemigos en esta planta. Creo que por ahora es seguro.[n][w][e]

[msg MSG_FUKA_NOT_ORDER_NOBTL [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5025 0 0]No percibo enemigos cerca. En esta planta deberíais estar a salvo.[n][w][e]

[msg MSG_MITU_ORDER_IN_GATE_0 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4025 0 0]Se ha abierto el camino. Ten cuidado cuando vayas por él.[n][w][e]

[msg MSG_FUKA_ORDER_IN_GATE_0 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5020 0 0]Parece que podemos seguir.[n][w][e]

[msg MSG_MITU_ORDER_IN_GATE_0_2 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4060 0 0]Ahora podrás seguir avanzando. ¿Por qué no echas un ojo?[n][w][e]

[msg MSG_FUKA_ORDER_IN_GATE_0_2 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5020 0 0]¿Se ha abierto ya el camino? ¿Podrías ir a echarle un ojo?[n][w][e]

[msg MSG_MITU_ORDER_IN_GATE_0_3 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4112 0 0]Parece que no puedes seguir avanzando. Esperaremos el momento adecuado para volver intentarlo.[n][w][e]

[msg MSG_FUKA_ORDER_IN_GATE_0_3 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]Creo que por ahora resulta imposible seguir avanzando. No nos queda otra que esperar.[n][w][e]

[msg MSG_MITU_ORDER_IN_HIGH_R [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]No pierdas de vista al enemigo que escapó antes.[n][w][e]

[msg MSG_FUKA_ORDER_IN_HIGH_R [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]¡Intenta encontrar al enemigo que escapó antes![n][w][e]

[msg MSG_FUKA_SUPPORT_SKILL_0 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5009 0 0]¿Qué ocurre?[n][w][e]

[msg MSG_FUKA_SUPPORT_SKILL_0_2 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5143 0 0]¿Necesitas mi ayuda?[n][w][e]

[msg MSG_FUKA_SUPPORT_SKILL_0_3 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 1 0 1 20131 0 0]¿Necesitabas algo?[n][w][e]

[msg MSG_FUKA_ORDER_FIRST [Mitsuru Kirijo]]

[msg MSG_FUKA_ORDER_ESCAPE [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Muy bien. ¿Seguro que quieres volver a la entrada ya?[n][w][e]

[msg MSG_FUKA_ORDER_ESCAPE_DO [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5145 0 0]¡De acuerdo! No te muevas de ahí, por favor.[n][w][e]

[msg MSG_FUKA_ORDER_ESCAPE_NO [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5056 0 0]Lo siento, pero parece que ahí no puedo usar mi habilidad.[n][w][e]

[msg MSG_FUKA_ORDER_SEARCH [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Muy bien. Quieres información sobre esta planta, ¿verdad?[n][w][e]

[msg MSG_FUKA_ORDER_SEARCH_DO [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5025 0 0]Haré una búsqueda y mostraré la información que encuentre.[n][w][e]

[msg MSG_FUKA_ORDER_SEARCH_NO [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5056 0 0]Lo siento, pero parece que ahí no puedo usar mi habilidad.[n][w][e]

[msg MSG_FUKA_ORDER_SEARCH_DO_2 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5061 0 0]Ya hemos recopilado toda la información posible sobre esta planta, así que eso no hace falta.[n][w][e]

[msg MSG_FUKA_ORDER_JAMMING [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Muy bien. No quieres que los enemigos de esta planta puedan detectarte, ¿no?[n][w][e]

[msg MSG_FUKA_ORDER_JAMMING_D [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5145 0 0]¡Genial! Ten en cuenta que esto no afecta a todos los enemigos, así que ve con cuidado.[n][w][e]

[msg MSG_FUKA_ORDER_JAMMING_N [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5056 0 0]Lo siento, pero parece que esto no tendrá ningún efecto.[n][w][e]

[msg MSG_FUKA_ORDER_JAMMING_D_2 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5061 0 0]¡Inhibición sigue activada, así que no hace falta activarla de nuevo![n][w][e]

[msg MSG_FUKA_ORDER_SFAURA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Muy bien. Quieres aumentar tu defensa y velocidad, ¿no?[n][w][e]

[msg MSG_FUKA_ORDER_SFAURA_DO [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5145 0 0]¡De acuerdo! Ten en cuenta que estas mejoras solo surtirán efecto a partir del próximo combate.[n][w][e]

[msg MSG_FUKA_ORDER_SFAURA_DO_2 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5064 0 0]La habilidad ya está en uso, así que no es necesario volver a activarla. ¡Verás sus efectos en la siguiente batalla![n][w][e]

[msg MSG_FUKA_ORDER_SHOCKN [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Muy bien. Quieres asustar a todos los enemigos de esta planta, ¿no?[n][w][e]

[msg MSG_FUKA_ORDER_SHOCKN_DO [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5117 0 0]¡Vale, allá vamos![n][w][e]

[msg MSG_FUKA_ORDER_SHOCKN_NO [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5056 0 0]Lo siento, pero parece que esto no tendrá ningún efecto.[n][w][e]

[msg MSG_FUKA_ORDER_SHOCKN_DO_2 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Ya he usado Ruido atemorizante en esta planta.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Es posible que no afecte a más enemigos. ¿Seguro que quieres volver a usarla?[n][w][e]

[msg MSG_FUKA_NOT_ENOUGH_SP [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5058 0 0]Lo siento, pero no me quedan energías.[n][w][e]

[msg MSG_FUKA_ORDER_RESTART [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]¿Necesitas algo más?[n][w][e]

[msg MSG_TARTARUS_FIRST_TRY_0 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4585 0 0]Derrota a todas las sombras de la planta.[n][w][e]

[msg MSG_TARTARUS_FIRST_TRY_0_2 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Ahora mismo no hay ningún enemigo, así que no hay necesidad de dar esa orden.[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0]Este es un buen momento para ordenar a tus compañeros que se dividan...[n][w][e]

[msg MSG_TARTARUS_FIRST_TRY_0_3 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4565 0 0]Ya no quedan más enemigos por derrotar. Usa el teletransportador para volver a la entrada.[n][w][e]

[msg TRL_TARTARUS_FIRST_TRY_H]
[f 2 1]DEV: Display help on instructions to split up at this time.[n][w][e]

[msg MSG_F031_OPERATION_01 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4143 0 0]Me preocupan los pasajeros. Tenemos que asegurar el monorraíl de inmediato.[n][w][e]

[msg MSG_F031_OPERATION_02 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4114 0 0]Por suerte, nadie ha resultado herido...[n][w][e]
[f 2 1][bup 5 0 65535 50 0 0]Pero ¿por qué no nos ha atacado aún el enemigo? ¿Significa esto que no atacan por atacar?[n][w][e]
[f 2 1][bup 5 0 65535 50 0 0]No sé qué está tramando el enemigo, pero será mejor que tengáis cuidado.[n][w][e]

[msg MSG_F031_OPERATION_03 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4099 0 0]¿El enemigo estaba esperando esta oportunidad?[n][w][e]
[f 2 1][bup 5 2 65535 50 0 0]¡Es demasiado peligroso para que Iori vaya solo! ¡Ve tras él![n][w][e]

[msg MSG_F031_OPERATION_04 [Mitsuru Kirijo]]
[f 2 1][bup 5 2 65535 50 0 0][vp 3 0 65535 4127 0 0]¡No hay tiempo! ¡Avanza hasta adelante del todo![n][w][e]

[msg MSG_F031_OPERATION_05 [Mitsuru Kirijo]]
[f 2 1][bup 5 2 65535 50 0 0][vp 3 0 65535 4092 0 0]¡Desde mi posición también se nota que el monorraíl ha acelerado![n][w][e]
[f 2 1][bup 5 2 65535 50 0 0]¡A esta velocidad, acabaremos estrellándonos![n][w][e]
[f 2 1][bup 5 2 65535 50 0 0]¡Concéntrate en llegar hasta adelante, derrotar al enemigo y detener el tren inmediatamente![n][w][e]

[msg MND_F052_OPERATION]
[f 2 1]No localizo a Mitsuru. Solo se escuchan interferencias...[n][w][e]

[msg MSG_THEURGIA_OPERATION_0 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5003 0 0]Hay un enemigo cerca. ¡Cuidado![n][w][e]

[msg MSG_THEURGIA_OPERATION_0_2 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5061 0 0]Todavía percibo algunos enemigos cerca. Estate alerta por si decides enfrentarte a ellos.[n][w][e]

[msg MSG_THEURGIA_OPERATION_0_3 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5145 0 0]Al parecer, has derrotado a todas las sombras de esta planta. Busca las escaleras para seguir avanzando.[n][w][e]

[msg MSG_THEURGIA_OPERATION_0_4 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5076 0 0]Hay algo raro en la planta de arriba. Ve con cuidado si vas a subir.[n][w][e]

[msg MSG_F034_OPERATION_01 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5076 0 0]El objetivo se encuentra en la tercera planta. ¡Deprisa, por favor![n][w][e]

[msg MSG_F034_OPERATION_02 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5011 0 0]Buen trabajo. Ya deberías poder volver.[n][w][e]

[msg MSG_F034_OPERATION_03 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5091 0 0]¡Cuidado! Parece que hay una sombra en esa estancia.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Pero... ¿dónde?[n][w][e]

[msg MSG_F034_OPERATION_04 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5145 0 0]A ver qué consigo averiguar. Por favor, no os separéis por ahora.[n][w][e]

[msg MSG_F034_OPERATION_05 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5076 0 0]Siento que en el espejo hay algo parecido a una sombra.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]¡Rompe el espejo, por favor![n][w][e]

[msg MSG_F034_OPERATION_06 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5061 0 0]Los espejos que estamos buscando deberían tener algo diferente. Examinadlos, a ver si encontráis qué es.[n][w][e]

[msg MSG_F034_OPERATION_07 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5006 0 0]¡Romped los espejos que no muestren vuestro reflejo![n][w][e]

[msg MSG_F034_OPERATION_08 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5020 0 0]¡El sello se ha roto! ¡Hay que ir de inmediato hacia el objetivo![n][w][e]

[msg MSG_F035_OPERATION_START [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]Capto dos señales intensas debajo de vosotros que proceden de nuestro objetivo.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Es como si las dos señales se solaparan y formaran una única masa gigante.[n][w][e]

[msg MSG_F035_OPERATION_01 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5006 0 0]El objetivo está bajando...[n][w][e]
[f 2 1][bup 6 2 65535 50 0 0]¡Vayamos a por él![n][w][e]

[msg MSG_F035_OPERATION_02 [Fuuka Yamagishi]]
[f 2 1][bup 6 2 65535 50 0 0][vp 3 0 65535 5008 0 0]El objetivo está esperando al final.[n][w][e]
[f 2 1][bup 6 2 65535 50 0 0]¡Mucho cuidado![n][w][e]

[msg MSG_TAR_ARRIVAL_FLOOR_MI [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4065 0 0]Lo más lejos que has llegado es el piso [f 2 4 0].[n][w][e]

[msg MSG_TAR_ARRIVAL_FLOOR_FU [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5145 0 0]Creo que lo más lejos que has llegado es el piso [f 2 4 0].[n][w][e]

[msg MSG_TAR_REAPER_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 2 65535 50 0 0][vp 3 0 65535 4143 0 0]¡Ha aparecido El segador! ¡Retiraos de inmediato![n][w][e]

[msg MSG_TAR_REAPER_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 2 65535 50 0 0][vp 3 0 65535 5103 0 0]¡Ha aparecido El segador! ¡Corred![n][w][e]

[msg MSG_TAR_REAPER_WARNING_M [Mitsuru Kirijo]]
[f 2 1][bup 5 4 65535 50 0 0][vp 3 0 65535 4099 0 0]¡¿Qué son estas señales?! ¡Se está acercando![n][w][e]

[msg MSG_TAR_REAPER_WARNING_F [Fuuka Yamagishi]]
[f 2 1][bup 6 4 65535 50 0 0][vp 3 0 65535 5120 0 0]¡Percibo algo poderoso que se aproxima a toda velocidad![n][w][e]

[msg MSG_TAR_MISNPC [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5076 0 0]¡En esta planta hay una persona! ¡Tenemos que salvarla![n][w][e]

[msg MSG_TAR_MISNPC_CAT [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]En esta planta hay algo... ¿Será una persona? ¡Búscala, por favor![n][w][e]

[msg MSG_TAR_FDOOR [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5061 0 0]Parece que una de esas puertas se encuentra en esta planta. Quizá deberíamos ir a buscarla.[n][w][e]

[msg MSG_TAR_ACCIDENT_00_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4104 0 0]En esta planta hay algo diferente. Será mejor estar alerta.[n][w][e]

[msg MSG_TAR_ACCIDENT_00_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]Hay algo diferente en esta planta...[n][w][e]

[msg MSG_TAR_ENDGATE_00_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4115 0 0]Se ha abierto el camino. Ten cuidado cuando vayas por él.[n][w][e]

[msg MSG_TAR_ENDGATE_00_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5145 0 0]Parece que el camino sigue. Vamos.[n][w][e]

[msg MSG_TAR_ENDGATE_01_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4143 0 0]Ahora podrás seguir avanzando. ¿Por qué no echas un ojo?[n][w][e]

[msg MSG_TAR_ENDGATE_01_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5020 0 0]¿Se ha abierto ya el camino? ¿Podrías ir a echarle un ojo?[n][w][e]

[msg MSG_TAR_ENDGATE_02_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4061 0 0]Parece que no puedes seguir avanzando. Esperaremos el momento adecuado para volver intentarlo.[n][w][e]

[msg MSG_TAR_ENDGATE_02_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]Creo que por ahora resulta imposible seguir avanzando. No nos queda otra que esperar.[n][w][e]

[msg MSG_TAR_GK_DEFEATED_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Se ha aniquilado al enemigo. Sigamos.[n][w][e]

[msg MSG_TAR_GK_DEFEATED_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Ya has derrotado al enemigo que estaba aquí. ¡En marcha![n][w][e]

[msg MSG_TAR_GK_EXIST_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Percibo a un enemigo poderoso más adelante. Procura ir bien preparada a la batalla.[n][w][e]

[msg MSG_TAR_GK_EXIST_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Un enemigo está bloqueando el paso, y es de los gordos. Prepárate para luchar.[n][w][e]

[msg MSG_TAR_JIN_DEFEATED [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Capto una presencia humana en la 263.ª planta. Debe de ser el último miembro de Strega.[n][w][e]

[msg MSG_TAR_JIN_EXIST [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Percibo que hay alguien en la 259.ª planta, y estoy segura de que es un miembro de Strega. Hay que ir con cuidado.[n][w][e]

[msg MSG_TAR_TAKAYA_DEFEATED [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Por fin hemos logrado conquistar esta torre gigantesca.[n][w][e]

[msg MSG_TAR_TAKAYA_EXIST [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Parece que el último miembro y líder de Strega se encuentra en la 263.ª planta.[n][w][e]

[msg MSG_TAR_NYX_EXIST [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5008 0 0]Por fin hemos llegado a la cima de la Tártaro. Aquí será nuestro último combate...[n][w][e]

[msg MSG_TAR_NEAR_ENDGATE_MIT [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Casi hemos llegado al final de esta zona. Sigamos avanzando.[n][w][e]

[msg MSG_TAR_NEAR_ENDGATE_FUK [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Ya casi hemos llegado al final de esta zona. ¡Aguantad ahí, chicos![n][w][e]

[msg MSG_TAR_MIDDLE_ENDGATE_M [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Aunque hemos avanzado bastante en esta zona, aún nos queda más terreno por explorar.[n][w][e]

[msg MSG_TAR_MIDDLE_ENDGATE_F [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Hemos avanzado un montón. Un tirón más y habremos llegado a la siguiente zona.[n][w][e]

[msg MSG_TAR_FAR_ENDGATE_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Aunque se han derrotado a los enemigos más fuertes de esta zona, aún queda un trecho para llegar al final.[n][w][e]

[msg MSG_TAR_FAR_ENDGATE_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Se han eliminado a todos los enemigos fuertes de esta zona. Ahora toca intentar acercarse lo máximo posible a la siguiente zona.[n][w][e]

[msg MSG_TAR_NEAR_GK_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Hay un enemigo poderoso cerca. Preparaos para la batalla.[n][w][e]

[msg MSG_TAR_NEAR_GK_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]¡Percibo un enemigo poderoso cerca! Será mejor prepararse para la batalla.[n][w][e]

[msg MSG_TAR_MIDDLE_GK_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Capto señales de un enemigo poderoso. Aunque aún estamos lejos, será mejor no bajar la guardia.[n][w][e]

[msg MSG_TAR_MIDDLE_GK_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Percibo que más adelante hay un enemigo de los fuertes. Ten cuidado al explorar la zona.[n][w][e]

[msg MSG_TAR_FAR_GK_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0]Parece que aún nos queda para cruzarnos con otro enemigo de los fuertes. Hay que avanzar con cautela.[n][w][e]

[msg MSG_TAR_FAR_GK_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Aunque aún queda para volver a enfrentarse a otro enemigo de los fuertes, no podemos bajar la guardia.[n][w][e]

[msg MSG_TAR_NEAR_JIN [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]¡Percibo que hay alguien en la 259.ª planta! Creo que es un miembro de Strega. ¡Id con cuidado![n][w][e]

[msg MSG_TAR_NEAR_TAKAYA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Percibo a una persona en la 263.ª planta. Debe de ser Takaya. Ha llegado la hora de ajustar cuentas con él.[n][w][e]

[msg MSG_TAR_NEAR_NYX [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Estamos cerca de la cima. Cuando lleguemos, será la hora de la batalla final.[n][w][e]

[msg MSG_Monad_NotDiscovery [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5003 0 0]Percibo algo totalmente nuevo... y no parece una sombra.[n][w][e]

[msg MSG_Monad_NotAccess [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]Es una puerta enorme. ¿Qué habrá tras ella?[n][w][e]

[msg MSG_Monad_BackEntrance [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5003 0 0]Tenéis que volver. Me gustaría repasar la información que tenemos sobre la puerta.[n][w][e]

[msg MSG_Monad_NowIn [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5089 0 0]El ambiente es diferente al de las otras plantas a las que estamos acostumbrados. Id con cuidado, por favor.[n][w][e]

[msg MSG_MonadPass_NotAccess [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]Hay que investigar la puerta. Quizá así averigüemos por qué es diferente al resto.[n][w][e]

[msg MSG_MonadPass_NowIn [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5089 0 0]Se palpa tanta tensión que hasta cuesta respirar.[n][w][e]

[msg MSG_JinFloor_NotDefeat [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5089 0 0]Siento la presencia de Strega más adelante. Id con cuidado.[n][w][e]

[msg MSG_JinFloor_Defeated [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5003 0 0]Hay otra persona en la 263.ª planta. Debe de ser el otro miembro de Strega.[n][w][e]

[msg MSG_TakayaFloor_NotDefea [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5089 0 0]Parece que el líder de Strega se encuentra más adelante.[n][w][e]

