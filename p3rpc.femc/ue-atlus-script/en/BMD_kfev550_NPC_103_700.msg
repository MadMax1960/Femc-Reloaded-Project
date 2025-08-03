[msg MSG_000_0_0 [Octopia Shopkeeper]]
[f 2 1][vp 3 0 65535 20101 0 0][f 5 21 1 103]Hey, come over here, young lady![n][w][e]
[f 2 1][vp 3 0 65535 20102 0 0][f 5 21 1 103]My takoyaki is both delicious and cheap! Only 400 yen![n][w][e]
[f 2 1][f 5 21 1 103]What, you thought you'd get a discount because it's New Year's? Just buy some! ...Please.[n][w][e]

[msg MND_001_0_0 [DEV: Internal MES]]
[f 2 1]Should I buy some takoyaki?[n][w][e]

[sel SEL_002_0_0 top]
[f 2 1]Buy[e]
[f 2 1]Don't buy[e]

[msg MND_003_0_0 [DEV: Internal MES]]
[f 2 1]I can't hold any more Weird Takoyaki.[n][w][e]

[msg MND_004_0_0 [DEV: Internal MES]]
[f 2 1]......[n][w][e]
[f 2 1]I don't have enough money...[n][w][e]

[msg MSG_005_0_0 [Octopia Shopkeeper]]
[f 2 1][vp 3 0 65535 20105 0 0][f 5 21 1 103]What? You aren't buying any? C'mon...[n][w][e]

[msg MSG_006_0_0 [Octopia Shopkeeper]]
[f 2 1][vp 3 0 65535 20105 0 0][f 5 21 1 103]Thanks! Come again![n][w][e]

