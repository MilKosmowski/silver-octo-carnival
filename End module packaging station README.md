# silver-octo-carnival

"End module packaging station":

TLDR - The program, in its current state, breaks every SOLID principle and needs a lot of refactoring.
It works fine, and handles tens of thousands products on a daily basis daily on multiple stations, but for the sake of scalability, product safety and common sence,
it needs a lot of work to be mainainable on the years to come.

What is it?

- Standalone .Net Framework WinForm application. 
- Made over the course of a few years. 
- Needs A LOT of refactiong, i started making it just after i started leaning C#.

How do you use it?

- You put a carton with a packaging label next to an automatic barcode scanner (SICK scanner, CLV650-6120 for instance).
- SICK scans the 1P (product part number), Q (quantity) and 3S (unique serial number).
- If everything's fine with the carton, and the program gives you the go-ahead, you scan the DataMatrix or QR code located on a product with a handheld scanner (Zebra DS4308 for instance),
- If the program accepts the QR code, it informs you about it, you physically put the product into the carton and continue scanning and packaging other products,
- When the carton is full, and no problems with the product were found, the program closes-up the carton in the database, informs you about it,
and you repeat the steps with another carton and packaging label,

What does it do?

- Uses two serial port scanners, one automatic and one handheld to scan a packaging label and barcodes located on a product to be packaged,
- Pairs the packaging label with scanned products, sends the data to two servers - one local, product tracking server, the other - global, corporate-wide, database,
- Queries the product tracking server for info about the packaging label - if it was previously used or not, if it has any products already associated with it. If it does, it acts accordingly,
- Queries the product tracking server for info about the product - if it went through all the required production processes, if it passed all of them, if it's already packaged.
If the program finds any discrepancies, it acts accordingly.
- Surprisingly, there's a lot that the operator could do wrong when packaging a product into a carton. Thus, the program has A LOT poka-yoke and baka-yoke logic,

