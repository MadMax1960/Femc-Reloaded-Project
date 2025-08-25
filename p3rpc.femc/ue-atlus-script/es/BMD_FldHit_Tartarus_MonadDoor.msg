[sel SEL_DOOR_FORWARD top]
[f 2 1]Entrar a Monad[e]
[f 2 1]Saltar al punto más lejano[e]
[f 2 1]Ahora mismo no[e]

[msg MND_CARD_SINGLE]
[f 2 1][f 4 4 1 0 1 0] está reaccionando...[n][w][e]

[msg MND_CARD_SOMETHING]
[f 2 1]Una de las cartas de los arcanos mayores está reaccionando...[n][w][e]

[msg MSG_OPEN_FUKA_00 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5076 0 0]Parece que la puerta se ha abierto.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Percibo sombras poderosas a través de ella... Ten cuidado.[n][w][e]

[msg MND_NOT_OPEN_00]
[f 2 1]La puerta está cerrada a cal y canto.[n][w][e]

[msg MSG_NOT_OPEN_FUKA_00 [Fuuka Yamagishi]]
[f 2 1][bup 6 6 65535 50 0 0]¿No ocurre nada...?[n][w][e]
[f 2 1][bup 6 6 65535 50 0 0]Eh... ¿Es posible que no tengas suficientes cartas del tarot?[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Igual nos hemos saltado una en alguna parte...[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]¿Te importaría echar un vistazo a las puertas de las plantas anteriores por si acaso?[n][w][e]

[msg MSG_NOT_OPEN_FUKA_01 [Fuuka Yamagishi]]
[f 2 1][bup 6 6 65535 65535 0 0]¿No ocurre nada...?[n][w][e]
[f 2 1][bup 6 6 65535 65535 0 0]Nos debe faltar la llave para abrirla...[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]Ahora que lo pienso, había una puerta similar en una planta inferior, ¿no?[n][w][e]
[f 2 1][bup 6 0 65535 65535 0 0]Podríamos encontrar una pista si abrimos la puerta primero.[n][w][e]

[msg MSG_ACCESS_FIRST_FUKA_00 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5028 0 0]Parece que no se abre... ¿Crees que falta algo?[n][w][e]

[msg MSG_ACCESS_FIRST_FUKA_01 [Fuuka Yamagishi]]
[f 2 1][bup 6 4 65535 50 0 0]¡Un momento! ¡La puerta brilla![n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Pero... ¿por qué de repente? ¿Has hecho algo, líder?[n][w][e]

[sel SEL_ACCESS_FIRST_00 top]
[f 2 1]La carta del tarot ha reaccionado.[e]
[f 2 1]Es una carta de los arcanos mayores...[e]

[msg MSG_ACCESS_FIRST_FUKA_02 [Fuuka Yamagishi]]
[f 2 1][bup 6 6 65535 50 0 0][vp 3 0 65535 5122 0 0]¿Una de tus cartas del tarot ha reaccionado ante la puerta...?[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Igual la carta es como una llave...[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Interesante... Sin duda esta puerta funciona de forma diferente a las que hemos visto.[n][w][e]

[msg SYS_ACCESS_FIRST [Fuuka Yamagishi]]

[msg MSG_OPEN_FIRST_FUKA_00 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5113 0 0]No percibo peligro en las inmediaciones...[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Sin embargo, podría haber un enemigo poderoso más adelante, como pasó con las demás puertas.[n][w][e]
[f 2 1][bup 6 2 65535 50 0 0]Si sientes que estás en peligro, sal de ahí rápidamente.[n][w][e]

[msg MND_DOOR_FORWARD_SEL]
[f 2 1]¿Exploramos Monad?[n][w][e]

[msg MSG_OPEN_FIRST_FUKA_10 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5061 0 0]Has entrado en las profundidades del pasillo.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]El pasillo está separado por puertas y es mucho más largo... Ten cuidado.[n][w][e]

[msg MSG_STOP_00 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5062 0 0]Puedes continuar avanzando por el pasillo. ¿Por qué no echas un vistazo?[n][w][e]

[msg MSG_NOT_OPEN_FUKA_10 [Fuuka Yamagishi]]
[f 2 1][bup 6 6 65535 50 0 0][vp 3 0 65535 5062 0 0]Parece la última puerta, pero... está cerrada.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Me pregunto si necesitamos algo más que cartas del tarot para abrirla...[n][w][e]

[msg MND_NOT_OPEN_10]
[f 2 1]Parece que falta algo para poder abrir esta puerta.[n][w][e]
[f 2 1]Volvamos por ahora...[n][w][e]

[msg MSG_NOT_OPEN_FUKA_11 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0][vp 3 0 65535 5003 0 0]¿Quién era esa señora de detrás de la puerta?[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Era preciosa y muy fuerte...[n][w][e]

[msg MND_NOT_OPEN_11]
[f 2 1]Mi batalla con Elizabeth ha terminado. Es hora de continuar...[n][w][e]

[msg MSG_RETURN_FUKA_00 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Parece que aquí no hay nada más. ¿Quieres volver?[n][w][e]

[sel SEL_RETURN_00 top]
[f 2 1]Salir de Monad[e]
[f 2 1]Quedarse más tiempo[e]

[msg MSG_RETURN_FUKA_10 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Muy bien.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]Ten cuidado en el camino de vuelta. Es fácil perderse.[n][w][e]

[msg MSG_RETURN_FUKA_11 [Fuuka Yamagishi]]
[f 2 1][bup 6 0 65535 50 0 0]Muy bien.[n][w][e]
[f 2 1][bup 6 0 65535 50 0 0]No percibo peligro alguno, pero no bajes la guardia.[n][w][e]

[msg MND_OPEN_20]
[f 2 1]Seguramente esta sea la ubicación de la que Elizabeth hablaba en su solicitud.[n][w][e]
[f 2 1]Tras esta zona, está el adversario definitivo...[n][w][e]

[msg MND_OPEN_21]
[f 2 1]Elizabeth nos espera tras este punto.[n][w][e]

[sel SEL_BTL_START top]
[f 2 1]Entrar[e]
[f 2 1]Prepararse primero[e]

[msg MND_NOT_OPEN_20]
[f 2 1]En la solicitud se especificaba que tendría que enfrentarme a este desafío yo sola.[n][w][e]
[f 2 1]Parece que la puerta no se abrirá si los demás están conmigo...[n][w][e]

