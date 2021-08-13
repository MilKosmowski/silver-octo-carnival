net use \\central_pack_3 /delete
net use \\central_pack_5 /delete
net use \\central_pack_6 /delete
net use \\central_pack_8 /delete

net use \\central_pack_3
net use \\central_pack_5
net use \\central_pack_6
net use \\central_pack_8

robocopy . "\\central_pack_3\C\Aplikacje\StanowiskoPakujace\Parameter\Central_pack_ustawienia\photos" /njh /njs /ndl /np /xx

robocopy . "\\central_pack_5\C\Aplikacje\StanowiskoPakujace\Parameter\Central_pack_ustawienia\photos" /njh /njs /ndl /np /xx

robocopy . "\\central_pack_6\C\Aplikacje\StanowiskoPakujace\Parameter\Central_pack_ustawienia\photos" /njh /njs /ndl /np /xx

robocopy . "\\central_pack_7\C\Aplikacje\StanowiskoPakujace\Parameter\Central_pack_ustawienia\photos" /njh /njs /ndl /np /xx

robocopy . "\\central_pack_8\C\Aplikacje\StanowiskoPakujace\Parameter\Central_pack_ustawienia\photos" /njh /njs /ndl /np /xx

pause