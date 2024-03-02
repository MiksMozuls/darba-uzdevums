# darba-uzdevums

Priekš aplikācijas tika izveidots ziņu skraiperis, kas savāc ziņas gan no tvnet, gan no LSM, 

Aplikācija sastāv no 3 daļām Datubāze (Mysql), backend (.NET) un frontend(React) lai to palaistu nepieciešams izmantot kommandu "docker-compose up" jo datubāze un frontends ir 2 docker faili uz viena network. 

Kad aplikācija palaidīsies tā sagaidīs līdz tā varēs sasniegt datubāzi, tad kad datubāze sasniegta var doties uz localhost:8004. 

Sasniedzot mājaslapa izskatīsies tukša bet nospiežot refresh sāks parādīties ziņas no portāliem, skatoties ka datubāze tiko izveidota, lai visas ziņas dabūtu var aizņemt kādu laiku bet ispējams aplūkot visu projektu
