INSERT INTO `recipes` (`id`, `title`, `content`, `prep_time`, `portion`) VALUES
(1, 'Mákos guba', 'A mákos guba elkészítéséhez a kifliket 1 cm-es karikákra vágjuk. A tejet a vaníliás cukorral felforraljuk. A kiflikarikákat a forró tejjel leöntjük, majd leszűrjük, és kinyomkodjuk belőle a tejet. Egy nagyobb jénai tálba egy réteg kiflit teszünk, majd porcukorral elkevert darált mákot szórunk rá, megint kiflit és megint mákot teszünk bele, amíg elfogynak a hozzávalók. Ha marad még mák, megszórjuk vele a tetejét is. Ha szeretnénk, akkor 7-8 percre berakhatjuk 180 fokra előmelegített sütőbe. Összemelegítve, sütve is nagyon finom, de ha nem akarjuk sütni, a mákos guba úgyis fogyasztható.', 30, 6),
(2, 'Csikós tokány', 'A szalonnát 3-4 milliméteresre csíkozzuk; a hagymát meghámozzuk, felkockázzuk; a paprikát megmossuk, felszeleteljük, majd a hagymához hasonló méretűre vágjuk; a hússzeleteket enyhén átlósan7-8 milliméteres csíkokra vágjuk; a fokhagymát megpucoljuk, apróra vágjuk; végül a paradicsomot is megmossuk, és felkockázzuk. Egy magas falú serpenyőben a szalonnát alacsony fokozaton, időnként kevergetve pár perc alatt átlátszóra pirítjuk, ezután hozzáadjuk a vöröshagymát, és együtt tovább dinszteljük. Hozzáadjuk a paprikát is, megborsozzuk, és addig pároljuk, amíg az alap opálosan áttetsző nem lesz. Ezután hozzáadjuk a tokányhúst, sózzuk, de csak óvatosan, mert a szalonna is sós, és fehéredésig pirítjuk. Ízesítjük a fokhagymával, majd fűszerezzük a pirospaprikával, alaposan elkeverjük, és a kockázott paradicsomot is beletesszük. Ezzel is jól elkeverjük, és felöntjük annyi vízzel, amennyi éppen ellepi, majd lefedjük, és takaréklángon nagyjából 60-70 perc alatt puhára pároljuk. Ha megpuhult, egy kis tálba kanalazzuk a tejfölt, hozzáadjuk a lisztet, és habverő segítségével csomómentesre keverjük, majd hőkiegyenlítéssel a raguhoz öntjük. Pár percig kevergetve készre főzzük a tokányt. Melegen, általában nokedlivel vagy tésztával, esetleg rizzsel és savanyúsággal fogyaszthatjuk ezt a szaftos-ízes megunhatatlan ősi ragut.', 80, 4),
(3, 'Lecsó', 'A lecsó elkészítéséhez a paradicsomot leforrázzuk, meghámozzuk, és gerezdekre vágjuk. A paprikát megmossuk, kicsumázzuk, ereit és magjait eltávolítjuk, majd  ujjnyi vastag karikákra szeljük. A hagymát meghámozzuk, és apróra felkockázzuk. A szalonnát ugyancsak apró kockákra vágjuk. Az olajra tesszük a szalonnát, és mérsékelt tűzön a zsírjából kisütjük. Megfonnyasztjuk benne a hagymát, majd lehúzzuk a tűzről, megszórjuk a pirospaprikával, rádobjuk a paradicsomot, és ízlés szerint megsózzuk. Visszatesszük a tűzre, és néhány percig fedő nélkül forraljuk. Beleforgatjuk a paprikát, és félig lefedve, mérsékelt tűzön puhára főzzük 15 perc alatt, végül megkóstoljuk, és újra megsózzuk, ha szülkséges. Friss kenyérrel kínáljuk.', 40, 4);

INSERT INTO `ingredients` (`id`, `name`, `amount`, `unit`, `recipe_id`) VALUES
(1, 'szikkadt kifli', 10, 'darab', 1),
(2, 'tej', 1, 'liter', 1),
(3, 'vaníliás cukor', 1, 'csomag', 1),
(4, 'darált mák', 15, 'evőkanál', 1),
(5, 'porcukor', 7, 'evőkanál', 1),
(6, 'füstölt kenyérszalonna', 15, 'dekagramm', 2),
(7, 't.v. paprika', 2, 'darab', 2),
(8, 'bors', 1, 'csipet', 2),
(9, 'szeletelt sertéslapocka', 80, 'dekagramm', 2),
(10, 'só', 1, 'csipet', 2),
(11, 'fokhagyma', 3, 'gerezd', 2),
(12, 'pirospaprika', 1, 'evőkanál', 2),
(13, 'paradicsom', 1, 'darab', 2),
(14, 'tejföl', 2, 'evőkanál', 2),
(15, 'liszt', 1, 'evőkanál', 2),
(16, 'paradicsom', 40, 'dekagramm', 3),
(17, 'paprika', 80, 'dekagramm', 3),
(18, 'hagyma', 2, 'fej', 3),
(19, 'füstölt szalonna', 5, 'dekagramm', 3),
(20, 'olaj', 2, 'evőkanál', 3),
(21, 'pirospaprika', 1, 'evőkanál', 3),
(22, 'só', 1, 'csipet', 3);

INSERT INTO `users` (`id`, `email`, `username`, `password`) VALUES
(1, 'juhasz.adel@gmail.com', 'jadel', '12345'),
(2, 'juhasz.blanka@gmail.com', 'jblanka', '12345');

INSERT INTO `comments` (`id`, `recipe_id`, `user_id`, `content`, `created_datetime`) VALUES
(1, 1, 1, 'Nagyon jó kis recept !!!', '2023-10-12 14:19:06'),
(2, 1, 2, 'Ízletes, bár én sokkal több porcukrot raktam bele', '2023-11-11 11:11:11'),
(3, 2, 1, 'Imádom!', '2023-11-20 11:11:11'),
(4, 2, 2, 'Nagyon jó!', '2023-11-23 18:02:04'),
(5, 3, 2, 'Élvezettel főzöm, jó recept! :)', '2023-11-27 07:00:23');
