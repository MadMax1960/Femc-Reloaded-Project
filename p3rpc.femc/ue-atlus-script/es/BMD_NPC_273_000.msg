[msg MSG_000_0_0 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]未使用[n][w][e]

[msg MSG_ELIZ_T_001 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13201 202 0]¿Ah? ¿Te puedo ayudar en algo?[n][w][e]

[msg MSG_ELIZ_T_002 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]¿Necesitas algo más?[n][w][e]

[msg MSG_ELIZ_T_005 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]¿En qué puedo ayudarte?[n][w][e]

[msg MSG_ELIZ_T_003 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]Gracias por lo de antes. Y bien, ¿en qué puedo ayudarte?[n][w][e]

[msg MSG_ELIZ_EXIT [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13204 202 0]Si requieres algo más, no dudes en preguntarme.[n][w][e]

[sel SEL_ELIZ_T_Daily_01 top]
[f 2 1]Sobre mis solicitudes[e]
[f 2 1]Proponer salir a Elizabeth[e]
[f 2 1]Entregar la bebida[e]
[f 2 1]Entregar la comida casera[e]
[f 2 1]Entregar la patata[e]
[f 2 1]Hablar[e]
[f 2 1]Da igual[e]

[sel SEL_ELIZ_T_Field_01 top]
[f 2 1]Sobre mis solicitudes[e]
[f 2 1]Entregar la bebida[e]
[f 2 1]Entregar la comida casera[e]
[f 2 1]Entregar la patata[e]
[f 2 1]Sobre los desaparecidos[e]
[f 2 1]Pedir cura[e]
[f 2 1]Hablar[e]
[f 2 1]Da igual[e]

[msg MSG_NPC_ELIZ_DATE_START [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]Uy...[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13202 202 0]Estaba esperando a que me lo pidieras. ¿Nos ponemos en marcha?[n][w][e]

[msg MSG_NPC_ELIZ_DATE_NG_1 [Elizabeth]]
[f 2 1][bup 202 3 65535 65535 0 0][vp 3 0 65535 13220 202 0]Mis más sinceras disculpas, pero preferiría que me invitaras durante el día...[n][w][e]

[msg MSG_NPC_ELIZ_DATE_NG_2 [Elizabeth]]
[f 2 1][bup 202 3 65535 65535 0 0][vp 3 0 65535 13220 202 0]Lo siento mucho, pero me temo que tendrá que ser otro día...[n][w][e]

[msg MND_NPC_ELIZ_DATE_NG_2]
[f 2 1]Ha rechazado mi invitación.[n][w][e]
[f 2 1]Debería centrarme en otras misiones por ahora.[n][w][e]

[msg MSG_NPC_ELIZ_DATE_NG_3 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Estoy considerando seriamente nuestro próximo destino. Por favor, aguarda un poco hasta que me haya decidido.[n][w][e]

[msg MND_NPC_ELIZ_DATE_NG_3]
[f 2 1]Elizabeth está pensando a dónde ir ahora...[n][w][e]
[f 2 1]Quizá pueda pedirle salir si completo más solicitudes...[n][w][e]

[msg MSG_NPC_ELIZ_DATE_NG_4 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13216 202 0]Por lo que he corroborado, creo que tu instituto está de "vacaciones", ¿verdad?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Quisiera experimentar la rutina diaria de un estudiante normal y corriente. ¿Me invitarías a un día de instituto?[n][w][e]

[msg MSG_NPC_ELIZ_DATE_NG_ALL [Elizabeth]]
[f 2 1][bup 202 3 65535 65535 0 0][f 4 25 202]...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0][vp 3 0 65535 13220 202 0]No puedo... hacer eso.[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Como ya te he dicho...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Mi máxima prioridad es cumplir con mi deber.[n][w][e]

[msg MSG_ELIZ_DATE_OPEN_1_1 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13201 202 0]Un segundo, por favor. Debo informarte de algo.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Con cada una de las solicitudes que completas, mi curiosidad por este mundo crece más y más...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Y ahora, ha surgido en mi interior el impulso de investigarlo yo misma.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Por tanto, me gustaría pedirte que me acompañaras a varias ubicaciones.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Primero, me gustaría que me guiaras por el centro comercial Paulownia.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13230 202 0]Si tienes tiempo, búscame mientras el sol esté brillando.[n][w][e]

[msg MSG_ELIZ_DATE_OPEN_1_2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13202 202 0]Te estaba esperando.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]En cuanto a mi petición de que me acompañaras a varias partes del mundo...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]En primer lugar, quiero ver el centro comercial Paulownia.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13230 202 0]Si tienes tiempo, búscame mientras el sol esté brillando.[n][w][e]

[msg MSG_ELIZ_DATE_OPEN_1_3 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13201 202 0]Un segundo, por favor. Debo informarte de algo.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Hasta ahora has cumplido bastantes solicitudes...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Este mundo es muy interesante, justo como pensaba. Tanto que ha surgido en mí el impulso de investigarlo de primera mano.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Por tanto, me gustaría pedirte que me acompañaras a varias ubicaciones.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13231 202 0]Acércate al centro comercial Paulownia más tarde y te daré más detalles.[n][w][e]

[msg MSG_ELIZ_DATE_OPEN_2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13201 202 0]¿Tienes un minuto?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Te pido humildemente que me vuelvas a acompañar a un lugar.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Esta vez, me gustaría visitar el área que se conoce como Iwatodai.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13231 202 0]Si tienes tiempo, búscame mientras el sol esté brillando.[n][w][e]

[msg MSG_ELIZ_DATE_OPEN_3 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13201 202 0]¿Tienes un minuto?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]¿Te importaría acompañarme una vez más...?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Esta vez, me gustaría ir a un lugar conocido como santuario Naganaki.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13231 202 0]Si tienes tiempo, búscame mientras el sol esté brillando.[n][w][e]

[msg MSG_ELIZ_DATE_OPEN_4 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13201 202 0]¿Tienes un minuto?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Me disculpo por lo repetitivo de mis peticiones, pero me gustaría pedirte que me acompañaras otra vez.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]¿Me llevarías al Instituto Gekkoukan, en el que asistes a clase?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13231 202 0]Si tienes tiempo, ven y házmelo saber después de clase.[n][w][e]

[msg MSG_ELIZ_DATE_OPEN_5 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13201 202 0]¿Tienes un minuto?[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Hay un sitio más que me gustaría visitar...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]¿Habría algún problema en invitarme a... tu habitación?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13231 202 0]Te estaré esperando aquí...[n][w][e]

[msg MSG_GIFT_RAREMEDAL_01 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Es como si tu presencia brillara mucho más que antes. Puede que tu trabajo esté empezando a dar frutos.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Toma. No es gran cosa, pero es un regalo de mi parte. Acéptalo.[n][w][e]

[msg MSG_GIFT_RAREMEDAL_02 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Puedo sentir que el poder que crece en tu interior proviene de los vínculos que has forjado y alimentado desde entonces.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Toma. No es gran cosa, pero es un regalo de mi parte. Acéptalo.[n][w][e]

[msg MSG_GIFT_RAREMEDAL_03 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Puedo ver que llevas una vida plena en la que cuidas de tus vínculos y te esfuerzas por superarte.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Más que una recompensa, es más bien un regalo. Tómalo.[n][w][e]

[msg MSG_GIFT_RAREMEDAL_04 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13230 202 0]Todavía no puedo prever los límites de tu potencial. Estoy deseando ver cuánto más puedes crecer...[n][w][e]

[msg MSG_MISSING_INFO_01 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13236 202 0]Percibo una presencia...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Siento una presencia humana en la torre Tártaro, entre las plantas [f 2 4 0] y [f 2 4 1].[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Será mejor que vayas en su busca para garantizar su seguridad cuanto antes.[n][w][e]

[msg MSG_MISSING_INFO_02 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13212 202 0]Veo que has rescatado a aquellos atrapados en la torre Tártaro.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Ya no percibo a nadie en la torre. Puedes descansar...[n][w][e]

[msg MSG_MISSING_INFO_03 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13216 202 0]Parece que tenemos un invitado con curiosidad felina maullando por las esquinas de la planta [f 2 4 2].[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Tenlo presente mientras exploras.[n][w][e]

[msg MSG_MISSING_INFO_04 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13215 202 0]No percibo personas perdidas en la torre Tártaro ahora mismo...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Sin embargo..., parece que contamos con un invitado felino maullando por las esquinas en su interior.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Debería estar en algún lugar de la planta [f 2 4 2]. Quizá deberías buscarlo.[n][w][e]

[msg MSG_INFO_LAST_DAY_HEAL [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13202 202 0]Por fin... Pronto llegarás a la cima de la torre para superar sus desafíos.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Haré lo que esté en mi mano para apoyarte hasta el final y que puedas hacerte con la victoria.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Si sientes que tu fuerza se desvanece, ven a verme y te curaré.[n][w][e]

[msg MSG_LAST_DAY_HEAL_01 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13204 202 0]Muy bien.[n][w][e]

[msg SYS_LAST_DAY_HEAL]
[f 2 1]¡Se han restaurado los PS y PE de todos![n][w][e]

[msg MSG_ELIZ_TALK_00 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13208 202 0]Veo que vienes para enfrentarte a la torre Tártaro. Asegúrate de prepararte correctamente...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Si tienes asuntos referentes a las Personas, visita la Habitación Terciopelo.[n][w][e]

[msg MSG_ELIZ_TALK_01 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13208 202 0]Si tienes asuntos referentes a las Personas, visita la Habitación Terciopelo.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]No obstante, puedes hablar conmigo aquí para lo referente a mis solicitudes.[n][w][e]

[msg MSG_ELIZ_TALK_02 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13216 202 0]Añadiré nuevas solicitudes de forma periódica. Te llegarán alrededor de una vez al mes.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Aunque algunas podrían estar disponibles solo tras completar otras solicitudes.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Presta atención al "número" de la solicitud.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13232 202 0]Si falta algún número, podría significar que alguna solicitud aún sigue oculta.[n][w][e]

[msg MSG_ELIZ_TALK_03 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Como dijo mi maestro, estrechar vínculos aumentará la fuerza de tus Personas.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Espero que disfrutes de una vida plena en la que puedas forjar muchas relaciones valiosas.[n][w][e]

[msg MSG_ELIZ_TALK_04 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13208 202 0]Ha llegado la hora.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Si necesitas ayuda, no dudes en hacérmelo saber, pues mi intención es ayudarte hasta el final.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_00 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13221 202 0]Madre mía...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Je, je... Vaya, me impresionas.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_01 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13221 202 0]Vaya, vaya, veo que tienes un [clr 35]Jack Frost[clr 27].[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Su adorable y redonda figura, su semblante travieso que hace imposible discernir sus pensamientos...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Es la perfección absoluta.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Ah, y si lo emparejas con [clr 35]Jack-o'-Lantern[clr 27], darán un espectáculo hilarante. Es más, podrías acabar hasta tirado en el suelo de la risa.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Si aún no lo has visto, te lo recomiendo fervientemente.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_02 [Elizabeth]]
[f 2 1][bup 202 4 65535 65535 0 0][vp 3 0 65535 13221 202 0]Madre mía...[n][w][e]
[f 2 1][bup 202 4 65535 65535 0 0]Tu [clr 35]Jack Frost[clr 27]... ha alcanzado el nivel 99.[n][w][e]
[f 2 1][bup 202 4 65535 65535 0 0]No me lo puedo creer. Pensar siquiera que esto pudiera pasar...[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0]Has debido pasar por increíbles dificultades para lograr que adquiera un poder tan asombroso...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13212 202 0]Es magnífico... Permíteme que te dé mis más sinceros elogios.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]No solo es adorable, sino que su poder no tiene rival.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Se ha convertido en una fuerza imparable.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]¿Que es débil al fuego, dices? Bueno, eso solo lo vuelve más fascinante.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_03 [Elizabeth]]
[f 2 1][bup 202 4 65535 65535 0 0][vp 3 0 65535 13215 202 0]Mmm. Orfeo, tu Persona...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Un ser que ha nacido tras forjar numerosos vínculos poderosos...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Percibo una fuerza inconmensurable y un potencial inigualable en su interior.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13230 202 0]Apenas puedo contenerme ante la perspectiva de un mayor crecimiento aún...[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_04 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]未使用[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_05 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13215 202 0]Me pregunto cuándo se cumplirá el deseo que pedí en la fuente.[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Todavía no he recibido ni confirmación ni un informe de avances...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0][vp 3 0 65535 13227 202 0]A lo mejor debería haber echado más dinero.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Qué remedio, la próxima vez doblaré la cantidad a 2 millones de yenes.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_06 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Gracias por dejarme disfrutar de tales exquisiteces el otro día.[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0]Estaban exquisitos, especialmente el takoyaki... Se ha vuelto una de mis comidas favoritas, rivalizando incluso con la harina de soja.[n][w][e]
[f 2 1][bup 202 2 65535 65535 0 0][vp 3 0 65535 13216 202 0]Desde entonces, mi interés por las delicias culinarias ha crecido. No obstante, mi posición actual supone un obstáculo.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Tras considerarlo detenidamente, he decidido aumentar el número de solicitudes culinarias.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13230 202 0]Espero con ganas que las completes.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_07 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13215 202 0]Intenté negociar los términos para incluir equipamiento de parque infantil en la Habitación Terciopelo...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0][vp 3 0 65535 13220 202 0]Por desgracia, mi proposición fue denegada. Qué decepción...[n][w][e]
[f 2 1][bup 202 2 65535 65535 0 0]Si no puedo obtener permiso, solo me queda aprovechar la ausencia de mi maestro.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13225 202 0]La victoria será mía... Aguarda las buenas noticias.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_08_ [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]Ah, sí... He oído que tu "instituto" suele organizar festivales de vez en cuando.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13215 202 0]Este "festival cultural" en particular parece una ocasión interesante.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13216 202 0]Además, he oído que podría desencadenar distorsiones en el continuo espacio-tiempo, transportándote a los "años de adolescente".[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Por desgracia, no tuve la oportunidad de observar dicho fenómeno durante la visita...[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13218 202 0]Pero, si surge la oportunidad, algún día me gustaría participar en el festival contigo.[n][w][e]

[sel SEL_ELIZ_UNIQUE_TALK_08 top]
[f 2 1]未使用[e]

[msg MSG_ELIZ_UNIQUE_TALK_08__2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]未使用[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_09 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13211 202 0]Gracias por lo del otro día...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Sobre lo que pasó en tu habitación...[n][w][e]
[f 2 1][bup 202 4 65535 65535 1 0][f 4 25 202]...[n][w][e]
[f 2 1][bup 202 4 65535 65535 1 0]Ejem... Perdóname, pero el recuerdo sigue muy... presente.[n][w][e]
[f 2 1][bup 202 0 65535 65535 1 0]Te agradecería que mantuvieras lo que pasó en secreto... Especialmente con mi maestro.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_10_ [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13215 202 0]Vaya, tu aura es distinta de la habitual... ¿Ha pasado algo?[n][w][e]

[sel SEL_ELIZ_UNIQUE_TALK_10 top]
[f 2 1]Fui a la playa.[e]
[f 2 1]Es un secreto.[e]

[msg MSG_ELIZ_UNIQUE_TALK_10__2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13221 202 0]Ah... La playa.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Creo que percibo el aroma del océano aún en ti.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_10__3 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13214 202 0]Qué decepción. No es mi intención entrometerme, pero...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]¿Tuviste eso que llaman "experiencia única en la vida"? He oído que normalmente sucede en verano.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_10__4 [Elizabeth]]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13218 202 0]En fin, me alegro de que te hayas divertido.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_11_ [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13216 202 0]He notado tu ausencia últimamente. ¿Has ido de viaje a algún sitio?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Ah, un viaje escolar... Donde uno se embarca en una travesía para refinar su cuerpo y su alma.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Entonces entiendo que has superado la prueba final. Fuiste la estudiante, pero ahora te has convertido en la maestra.[n][w][e]

[sel SEL_ELIZ_UNIQUE_TALK_11 top]
[f 2 1]Solo ha sido un viaje.[e]
[f 2 1]No creo que sea posible.[e]

[msg MSG_ELIZ_UNIQUE_TALK_11__2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13214 202 0]Anda, no me digas. Lo siento.[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0]En fin, lo importante es que fuera una buena experiencia.[n][w][e]
[f 2 1][bup 202 4 65535 65535 0 0]¿Mmm? ¿Ha ocurrido algo? Te veo un poco lúgubre.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_12 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13212 202 0]Vaya, vaya... Parece que has forjado un nuevo vínculo, uno diferente y mucho más fuerte que los demás.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][f 4 25 202]...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Y el vínculo que compartís se estrechará aún más, entrelazando sus destinos al tuyo...[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Debo admitir que me da un poco de envidia.[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0][f 4 25 202]...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13208 202 0]Mis disculpas. Abraza con fuerza ese vínculo. Ese vínculo tan valioso y especial...[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_13_ [Elizabeth]]
[f 2 1][bup 202 3 65535 65535 0 0][f 4 25 202]...[n][w][e]

[sel SEl_ELIZ_UNIQUE_TALK_13 top]
[f 2 1]¿Qué sucede?[e]
[f 2 1]Te veo de bajón.[e]

[msg MSG_ELIZ_UNIQUE_TALK_13__2 [Elizabeth]]
[f 2 1][bup 202 4 65535 65535 0 0][vp 3 0 65535 13226 202 0]Pido disculpas.[n][w][e]
[f 2 1][bup 202 3 65535 65535 0 0]Tras ese enfrentamiento contigo, siento que me pierdo en mis propios pensamientos más a menudo...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Pero no tienes que preocuparte por ello.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Creo que es algo que podré superar...[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_14_ [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13202 202 0]Ha llegado la hora.[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0][f 4 25 202]...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Pareces poseer una fuerza especial que te permite superar cualquier obstáculo que se interponga en tu camino.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Aunque tu historia pueda acabar en tragedia...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Puedo decir con seguridad que perseverarás para alcanzar el mejor resultado.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13204 202 0]Que la diosa de la fortuna te sonría.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_14__2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]Creo firmemente que puedes superar cualquier obstáculo.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13204 202 0]Que la diosa de la fortuna te sonría.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_15 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Mmm... Parece que has crecido de manera espectacular.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Creo que ahora podrás utilizar varias Personas.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Pero, en cuanto a tu potencial, esto es solo el principio de lo que puedes conseguir...[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13230 202 0]Mejora a tus Personas y alcanza cotas más altas.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_16 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Vaya... Parece que has experimentado un crecimiento significativo.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Se podría decir que esto es la culminación de tu habilidad para atraer a los demás.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Quizá ahora seas capaz de forjar vínculos con los demás fácilmente.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_17 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13221 202 0]Y así, has completado todas las solicitudes.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Eso significa que no recibirás ninguna más de mí.[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13222 202 0]Pensar que este día llegaría... Es conmovedor, de verdad.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Soy consciente de que algunas solicitudes eran poco razonables, pero has actuado de forma espléndida.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13211 202 0]Permíteme que te dé las gracias.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_18_ [Elizabeth]]
[f 2 1][bup 202 4 65535 65535 0 0][vp 3 0 65535 13215 202 0]Ah, ¿eso es...?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]¿Me permites ver ese broche que llevas?[n][w][e]

[msg MND_ELIZ_UNIQUE_TALK_18_ [Elizabeth]]
[f 2 1]Le he dado el [f 4 4 1 37 1 0] a Elizabeth.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_18__2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]Qué diseño tan complicado... ¡Y de platino, nada menos![n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Adoro los artículos fabricados con platino...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13222 202 0]Qué exquisitez... No sabía que se podrían adquirir tales creaciones maestras en tu mundo.[n][w][e]

[sel SEL_ELIZ_UNIQUE_TALK_18 top]
[f 2 1]¿Lo quieres?[e]
[f 2 1]Me gustaría darte esto.[e]

[msg MSG_ELIZ_UNIQUE_TALK_18__3 [Elizabeth]]
[f 2 1][bup 202 4 65535 65535 0 0][vp 3 0 65535 13221 202 0]¿Me permites?[n][w][e]
[f 2 1][bup 202 0 65535 65535 1 0]Gracias...[n][w][e]
[f 2 1][bup 202 0 65535 65535 1 0]Aunque esto no constituye una solicitud, permíteme recompensarte de todos modos.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_18__4 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13211 202 0]Lo atesoraré por siempre.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_19_ [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13215 202 0]Vaya, ¿qué tenemos aquí? Parece un muñeco.[n][w][e]

[msg MND_ELIZ_UNIQUE_TALK_19_ [Elizabeth]]
[f 2 1]Le he enseñado el [f 4 4 1 37 1 0] a Elizabeth.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_19__2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13214 202 0]¿Conque esto se llama "Ídolo de ojos desorbitados"?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Parece bastante antiguo. Además, se ve que quien lo fabricó se esforzó mucho en los detalles...[n][w][e]
[f 2 1][bup 202 4 65535 65535 0 0]Ahora que lo pienso... ¿No te recuerda a una Persona en especial?[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13224 202 0]Mm... Tal vez por eso mismo me ha llamado la atención.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Gracias por dejar que lo estudie. Te lo devuelvo.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20_ [Elizabeth]]
[f 2 1][bup 202 1 65535 65535 0 0]No sé por qué, pero tengo unas ganas enormes de, como decís los humanos, "ponerme accesorios".[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Quizá esta es la ocasión perfecta para ponerme esos objetos que me has traído...[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]¿Tienes alguna sugerencia?[n][w][e]

[sel SEL_ELIZ_UNIQUE_TALK_20_ top]
[f 2 1]Gafas de diseño[e]
[f 2 1]Orejas de gato[e]
[f 2 1]Gafas de broma[e]
[f 2 1]Gorro de Papá Noel[e]

[msg MSG_ELIZ_UNIQUE_TALK_20__3 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13235 202 0]Entonces, sin más dilación...[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__4 [Elizabeth]]
[f 2 1][bup 202 0 901 65535 0 0]¿Qué te parece?[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__5 [Elizabeth]]
[f 2 1][bup 202 0 902 65535 0 0]¿Qué te parece?[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__6 [Elizabeth]]
[f 2 1][bup 202 0 903 65535 0 0]¿Qué te parece?[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__7 [Elizabeth]]
[f 2 1][bup 202 0 904 65535 0 0]¿Qué te parece?[n][w][e]

[sel SEL_ELIZ_UNIQUE_TALK_20__2 top]
[f 2 1]Qué bien te veo.[e]
[f 2 1]Hazlo parte de tu aspecto.[e]

[msg MSG_ELIZ_UNIQUE_TALK_20__8 [Elizabeth]]
[f 2 1][bup 202 1 901 65535 0 0][vp 3 0 65535 13211 202 0]Vaya, gracias. Admito que estoy despampanante.[n][w][e]
[f 2 1][bup 202 0 901 65535 0 0]No hay nada que levante más el ánimo que embellecer tu aspecto con un adorno.[n][w][e]
[f 2 1][bup 202 0 901 65535 0 0]Ah, pero no puedo dejarme llevar hasta el punto de olvidar mi deber. Suficiente distracción por hoy.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__9 [Elizabeth]]
[f 2 1][bup 202 1 902 65535 0 0][vp 3 0 65535 13211 202 0]Vaya, miauci beaucoup. Esto... quería decir "gracias".[n][w][e]
[f 2 1][bup 202 0 902 65535 0 0]Llevar esto puesto te hace sentir como si poco a poco te transformaras en un gato.[n][w][e]
[f 2 1][bup 202 0 902 65535 0 0]Pero es suficiente por ahora. La verdad es que no me gustaría transformarme en gato.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__10 [Elizabeth]]
[f 2 1][bup 202 1 903 65535 0 0][vp 3 0 65535 13211 202 0]Gracias... ¡Achís![n][w][e]
[f 2 1][bup 202 0 903 65535 0 0]Mis disculpas. Aún me estoy acostumbrando a lo que pica esta barba, vaya.[n][w][e]
[f 2 1][bup 202 0 903 65535 0 0]Pero, desde luego, ha satisfecho el impulso. Suficiente disfraz por hoy.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__11 [Elizabeth]]
[f 2 1][bup 202 1 904 65535 0 0][vp 3 0 65535 13211 202 0]Ay, gracias.[n][w][e]
[f 2 1][bup 202 0 904 65535 0 0]Ponerme esto me ha puesto de un humor bastante festivo. Es difícil contener el impulso de entregar regalos...[n][w][e]
[f 2 1][bup 202 0 904 65535 0 0]Por desgracia, no tengo nada que darte en este momento. Quizá otra vez será.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__12 [Elizabeth]]
[f 2 1][bup 202 3 901 65535 0 0][vp 3 0 65535 13220 202 0]No niego que surjan de mi interior tales impulsos de vez en cuando...[n][w][e]
[f 2 1][bup 202 3 901 65535 0 0]Mi deber es servir a mi maestro. No deseo causarle problemas.[n][w][e]
[f 2 1][bup 202 0 901 65535 0 0]Por tanto..., creo que es suficiente distracción por hoy.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__13 [Elizabeth]]
[f 2 1][bup 202 3 902 65535 0 0][vp 3 0 65535 13220 202 0]Si mi situación lo permitiera, me habría encantado hacerlo.[n][w][e]
[f 2 1][bup 202 3 902 65535 0 0]Sin embargo, ponerme esto me permite transformarme en un gato mental y físicamente...[n][w][e]
[f 2 1][bup 202 0 902 65535 0 0]Para poder cumplir mis tareas, debo evitar llevarlo puesto habitualmente...[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__14 [Elizabeth]]
[f 2 1][bup 202 2 903 65535 0 0][vp 3 0 65535 13220 202 0]No niego que surjan de mi interior tales impulsos de vez en cuando...[n][w][e]
[f 2 1][bup 202 3 903 65535 0 0]Sin embargo, llevarlo hace que me pique la nariz...[n][w][e]
[f 2 1][bup 202 0 903 65535 0 0]Me temo que interferirá con mis deberes. Lo reservaré para una ocasión especial.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__15 [Elizabeth]]
[f 2 1][bup 202 0 904 65535 0 0][vp 3 0 65535 13220 202 0]Si mi situación lo permitiera, me habría encantado hacerlo.[n][w][e]
[f 2 1][bup 202 3 904 65535 0 0]Sin embargo, llevarlo puesto dificulta reprimir el impulso de repartir regalos...[n][w][e]
[f 2 1][bup 202 0 904 65535 0 0]Pero, para cumplir con mi deber, lo llevaré cuando desees.[n][w][e]

[msg MSG_ELIZ_UNIQUE_TALK_20__16 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Gracias por concederme el gusto.[n][w][e]

[msg MSG_SUBMIT_DRINK_QUERY_1 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]¿Has podido reunir las bebidas de las máquinas expendedoras?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13231 202 0]Ya veo... De todas las distintas bebidas disponibles, has conseguido reunir [f 2 4 0]. ¿Serás capaz de reunir [f 2 4 1] más?[n][w][e]

[msg MSG_SUBMIT_DRINK_QUERY_2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13202 202 0]Parece que has reunido las distintas bebidas. ¿Te importa si las cojo ya?[n][w][e]

[sel SEL_SUBMIT_DRINK_2 top]
[f 2 1]Entregar las bebidas[e]
[f 2 1]No[e]

[msg MSG_SUBMIT_DRINK_END_CAN [Elizabeth]]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13204 202 0]Entiendo... Menuda decepción. Otra vez será.[n][w][e]

[msg MSG_SUBMIT_DRINK_COMPLET [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13221 202 0]Madre mía, ¡cuántas bebidas! Sería un desperdicio bebérselas sin más.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Quizá hoy pueda llevar a cabo el ritual de los trabajadores conocido como "un trago al salir de trabajar"...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]En cualquier caso, has completado la solicitud. Llévate esta recompensa.[n][w][e]

[msg MSG_SUBMIT_ITEM_IMO_1 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13216 202 0]Presiento un poder inusual en ti. Por casualidad, ¿tienes una de las patatas que has cultivado?[n][w][e]

[sel SEL_SUBMIT_ITEM_IMO_2 top]
[f 2 1]Patata Tarukaja[e]
[f 2 1]Patata Sukukaja[e]
[f 2 1]Patata Rakukaja[e]
[f 2 1]Patata Matarukaja[e]
[f 2 1]Patata Subidón[e]
[f 2 1]No le des patata[e]

[msg MSG_SUBMIT_ITEM_IMO_3 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]Qué patata tan extraña... De ella emana un poder inusual.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13228 202 0]Seguro que resulta en una comida "dura de pelar".[n][w][e]
[f 2 1][bup 202 4 65535 65535 0 0]¿Mm? ¿Por qué me miras así?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13212 202 0]En cualquier caso, has completado la solicitud. Llévate esta recompensa.[n][w][e]

[msg MSG_SUBMIT_ITEM_IMO_4 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13204 202 0]Entiendo... Menuda decepción. Otra vez será.[n][w][e]

[msg MSG_SUBMIT_DISH_1 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13202 202 0]¿Mm? Parece que tienes lo que creo que es una "comida casera"...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]¿Qué me ofreces?[n][w][e]

[sel SEL_SUBMIT_DISH top]
[f 2 1]Pollo salteado[e]
[f 2 1]Crema de repollo[e]
[f 2 1]Comida de deportistas duros[e]
[f 2 1]Comida de superdeportistas[e]
[f 2 1]Café corriente y moliente[e]
[f 2 1]Café excelente[e]
[f 2 1]Té de noche de calidad[e]
[f 2 1]Karume-yaki[e]
[f 2 1]Katsudon exquisito[e]
[f 2 1]Tempura espectacular[e]
[f 2 1]Té decadente[e]
[f 2 1]Nada[e]

[msg MSG_SUBMIT_DISH_REPLY_1 [Elizabeth]]
[f 2 1][bup 202 4 65535 65535 0 0][vp 3 0 65535 13221 202 0]Vaya. Creo que es la primera vez que lo pruebo, pero este sabor me resulta... nostálgico.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Vaya, conque esto es una comida "casera"...[n][w][e]

[msg MSG_SUBMIT_DISH_REPLY_2 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13208 202 0]Aunque su presentación es sencilla y rudimentaria, se ve que fue preparada con cuidado.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Esta consideración debe de ser un elemento importante para que un plato sea realmente "casero"...[n][w][e]

[msg MSG_SUBMIT_DISH_REPLY_3 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]El concepto "casero", presuntamente, evoca un sentimiento de calidez y confort.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Aunque el café tiene un gusto amargo, su calidez emana un sentimiento muy reconfortante.[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0]En otras palabras, algo que se ha hecho de forma "casera" puede... sosegar tu alma.[n][w][e]

[msg MSG_SUBMIT_DISH_REPLY_4 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13221 202 0]Así que a esto sabe la "cocina casera"...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Un sabor rico y elegante. Una sensación de lujo en el paladar.[n][w][e]

[msg MSG_SUBMIT_DISH_REPLY_5 [Elizabeth]]
[f 2 1][bup 202 4 65535 65535 0 0][vp 3 0 65535 13222 202 0]¡Vaya! Una presentación que hace relucir el encanto y el atractivo del plato...[n][w][e]
[f 2 1][bup 202 4 65535 65535 0 0]Una innovadora combinación de sabores que engaña a la mente para que lo saboree por toda la eternidad...[n][w][e]
[f 2 1][bup 202 1 65535 65535 0 0][vp 3 0 65535 13212 202 0]Oh, ¡es excepcional! Nunca imaginé que la comida pudiera agitar tanto las emociones de una persona...[n][w][e]

[msg MSG_SUBMIT_DISH_END [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]Creo que entiendo por qué la gente ansía tanto el sabor de la comida casera...[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13211 202 0]Te agradezco que compartas esta delicia culinaria. Toma esto como recompensa.[n][w][e]

[msg MSG_SUBMIT_DISH_CANCEL [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13204 202 0]Entiendo... Menuda decepción. Otra vez será.[n][w][e]

[msg MSG_REQ_HELP_030_1 [Elizabeth]]
[f 2 1][bup 202 0 65535 65535 0 0]¿Eh? ¿Ocurre algo?[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13214 202 0]Entiendo... Así que hay individuos en tu mundo que buscan dichos materiales.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]Puedes encontrar una [f 4 4 1 37 1 0] en Arqa, la segunda sección de la torre Tártaro.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0]He oído que a la "[clr 2]Serpiente lujuriosa[clr 27]" que aparece en la segunda mitad de la sección le gusta coleccionar ese objeto.[n][w][e]
[f 2 1][bup 202 0 65535 65535 0 0][vp 3 0 65535 13218 202 0]Un material que cautiva tanto a sombras como a humanos. Es de lo más peculiar...[n][w][e]

