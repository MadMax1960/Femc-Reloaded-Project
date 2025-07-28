[sel SEL_EXPLORATION top]
[f 2 1]Reanudar desde P[f 2 4 0][e]
[f 2 1]Usar el teletransportador[e]
[f 2 1]No usar[e]

[sel SEL_YESNO top]
[f 2 1]Sí.[e]
[f 2 1]Un momento.[e]

[sel SEL_CheckFull top]
[f 2 1]Usar el teletransportador[e]
[f 2 1]No usar[e]

[msg MSG_ACCESS_MITSURU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 65535 0 0][vp 3 0 65535 4001 0 0]Has explorado hasta la planta [f 2 4 0]. ¿En qué punto quieres reanudar la expedición?[n][w][e]

[msg MSG_ACCESS_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 65535 0 0][vp 3 0 65535 5003 0 0]Parece que has llegado a la planta [f 2 4 0]. ¿Adónde quieres saltar ahora?[n][w][e]

[msg MSG_THEURGIA_FUKA_OK_00 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 65535 0 0][vp 3 0 65535 5145 0 0]¿Estás lista?[n][w][e]

[msg MSG_THEURGIA_FUKA_OK_02 [Fuuka Yamagishi]]
[f 2 1][bup 6 1 65535 65535 0 0]Intentaré llevarte a una planta más tranquila.[n][w][e]
[f 2 1][bup 6 1 65535 65535 0 0]No puedo ir contigo, ¡pero intentaré cubrirte lo mejor que pueda desde aquí![n][w][e]

[msg MSG_START_MITSURU_OK_10 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 65535 0 0]Entendido.[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0]Siempre que sigas mis instrucciones, irás por una ruta segura.[n][w][e]

[msg MSG_START_MITSURU_OK_11 [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 65535 0 0]¿La planta [f 2 4 0]? Entendido. El teletransportador te debería llevar hasta allí sin rodeos.[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0]Cuídate mucho.[n][w][e]

[msg MSG_START_FUKA_OK_10 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 65535 0 0]Vale, entendido.[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]Voy a buscar una ruta segura hasta allí, así que ve siguiendo el camino que te indico.[n][w][e]

[msg MSG_START_FUKA_OK_11 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 65535 0 0]¿Quieres ir a la planta [f 2 4 0]? Vale, si pillas el teletransportador, ¡estarás allí en un abrir y cerrar de ojos![n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]¡Buen viaje![n][w][e]

[msg MSG_ADVICE_MITSURU_MAY [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 65535 0 0][vp 3 0 65535 4073 0 0]Necesito contarte algo.[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0]¿Recuerdas lo que te dije sobre que la torre Tártaro se dividía en diferentes zonas?[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0]Bueno, gracias al poder de Pentesilea, he detectado una señal extraña pasada la 20.ª planta...[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0]Puede que algo haya cambiado. Deberías ir a esa zona y comprobarlo por ti misma.[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0]Confiamos en ti.[n][w][e]

[msg MSG_ADVICE_FUKA_MAY [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 65535 0 0][vp 3 0 65535 5061 0 0]Líder, ¿tienes un momento?[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]¿Recuerdas que Kirijo dijo que la torre Tártaro se dividía en diferentes zonas?[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]Bueno, una de esas zonas debería acabar en la 22.ª planta, pero detecto una señal un tanto extraña allí.[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]Es inestable, como si se estuviese moviendo o algo...[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]Bueno, para la expedición de hoy, te diría que explorásemos la 22.ª planta.[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]Mucho cuidado y buena suerte.[n][w][e]

[msg MND_WARP_FIRST]
[f 2 1]Esta consola muestra una serie de números...[n][w][e]

[msg MSG_WARP_FIRST_MITSURU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4061 0 0]Mmm, entiendo...[n][w][e]
[f 2 1][bup 5 0 65535 50 0 0]Venga, selecciona la 1.ª planta en el dispositivo. Con eso, deberías volver.[n][w][e]

[msg MSG_WARP_FIRST_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 1 65535 50 0 0][vp 3 0 65535 5079 0 0]Anda, ¡qué interesante![n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]¿Puedes seleccionar la 1.ª planta? Creo que así vendrás derechita de vuelta.[n][w][e]

[msg MND_WARP_NOT_BOOT]
[f 2 1]¿Qué es esto? Jamás he visto cosa igual.[n][w][e]
[f 2 1]No parece que funcione ahora mismo.[n][w][e]

[msg MND_WARP_NOT_BOOT_2]
[f 2 1]Por lo visto, he podido volver al usar un teletransportador unidireccional en la Tártaro.[n][w][e]
[f 2 1]Aunque no parece que pueda usarlo para volver a la planta en la que estaba.[n][w][e]

[msg MSG_MITSURU_GREET [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 65535 0 0][vp 1 0 1 10099 0 0]Gracias a Yamagishi, también puedo explorar contigo. Pero me gustaría seguir con la estrategia de cuatro personas.[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0][vp 1 0 1 10100 0 0]Solo para tener refuerzos que acudan en nuestra ayuda en caso de emergencia.[n][w][e]
[f 2 1][bup 5 0 65535 65535 0 0][vp 1 0 1 10101 0 0]Y acuérdate de lo que pasó durante la última luna llena. No podemos dejarla sola.[n][w][e]
[f 2 1][bup 5 1 65535 65535 0 0][vp 1 0 1 10102 0 0]Te dejo a ti decidir qué miembros incluir en el grupo. Confío en ti.[n][w][e]

[msg MSG_FUKA_GREET [Fuuka Yamagishi]]
[f 2 1][bup 6 2 65535 65535 0 0][vp 1 0 1 10103 0 0]Haré todo lo que esté en mi mano para ayudar. ¡Nos esforzaremos al máximo![n][w][e]

[msg DESC_FLOOR21_NG_MITU [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 50 0 0][vp 3 0 65535 4032 0 0]Espera... Vale, el camino es seguro.[n][w][e]
[f 2 1][bup 5 0 65535 50 0 0]Me pica la curiosidad por saber qué hay en la siguiente planta. Sigue avanzando.[n][w][e]

[msg DESC_FLOOR21_NG_FUKA [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5061 0 0]Espera un momento... Vale, parece que es seguro continuar.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Me gustaría saber qué hay en el piso de arriba. ¿Te parece bien que sigamos?[n][w][e]

[msg MSG_Mitsuru_NotFull [Mitsuru Kirijo]]
[f 2 1][bup 5 0 65535 65535 0 0][vp 3 0 65535 4008 0 0]¿Estáis listos?[n][w][e]
[f 2 1][bup 5 3 65535 65535 0 0]Si es posible, yo iría con el grupo al completo.[n][w][e]

[msg MSG_Fuka_NotFull [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 65535 0 0][vp 3 0 65535 5008 0 0]¿Lista para empezar a explorar?[n][w][e]
[f 2 1][bup 6 3 65535 65535 0 0]Ah, em... ¿Seguro que no quieres ir con el grupo al completo? ¿Irá todo bien?[n][w][e]

