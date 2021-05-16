
Minden code review, projekt átvizsgálása során az első lépés, hogy az adott projektet valamilyen kategóriába be kell sorolni. Jelen project esetében nem egy összefüggő komplex egész rendszerről beszélhetünk, hanem több különálló önmagában is értelmes és használható algoritmusokat és adatszerkezeteket találhatunk. Az egyes algoritmusok és adatszerkezetek egy egy külön deklarációs fájlban kerültek implementálásra ezzel biztosítva, hogy az egyes osztályokon belül erős kohézió és a többi osztályhoz képest pedig gyenge csatolás valósuljon meg. Amit már itt fontos megemlíteni, hogy ez nagy mértékben elősegíti az egyes osztályok külön történő egységtesztelését. A projekt felépítése is a .NET-ben megismert konvenciókat követi. Megfigyelhető hogy maga a solution három projektből épül fel. Külön projektbe kerültek az algoritmusok és az adatszerkezetek is. A harmadik project pedig az egységtesztelés céljából jött létre. Maga a solution felépítéséből következik, hogy érdemesebbnek láttuk, hogyha az egység tesztelésre fektetünk nagyobb hangsúlyt. A cél a minél nagyobb kód lefedettség elérése volt.

A házifeladatunk során a következő feladatokat valósítottuk meg:
- Unit tesztek készítése a kis lefedettségű osztályokhoz
- Néhány osztály átvizsgálása SonarLint segítségével majd az általunk is valódi problémának vélt figyelmeztetések javítása
- Teljesítmény teszt végzése, a sorbarendező algoritmusok összehasonlítása egymással, illetve a .NET-ben található implementációval
- BDD tesztek készítése a kis lefedettségű osztályokhoz

A fenti feladatok eredményeinek részletes dokumentációja egy-egy makdown fájlban található a `doc` könyvtárban.
