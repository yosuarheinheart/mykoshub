Instruksi Install Aplikasi MyKosHub

1. Buka folder "Source Code MyKosHub" yang berisikan file folder Bernama "MyKosHub" yang sudah mengandung seluruh source code dari aplikasi Winforms (.NET) MyKosHub terlebih dahulu.
2. Masuk ke dalam folder 'MyKosHub' tersebut dan buka file "MyKosHub.sln" pada software visual studio.
3. Buka SQL Server Management Studio (SSMS) atau perangkat lainnya yang mendukung database SQL Server.
4. Dengan menggunakan SSMS, maka silahkan ikuti langkah berikut:
   1) 	Saat ingin login ke database, pada halaman Login. Di menu Server, Pastikan server name yang terpilih sesuai dengan yang diinginkan dan simpan server name tersebut.
   2)	Untuk opsi Authentication, pilih opsi "Window Authentication".
   3)	Dalam menu Connection Security, pilih "Mandatory" dan centang "Trust server certificate".
   4)	Setelah tekan tombol "Connect".
5. Buka menu Object Explorer di SSMS.
6. Expand sampai menemukan folder bernama "Databases".
7. Klik kanan pada folder tersebut dan pilih Import Data Tier Application, lalu Next
9. Lakukan browse untuk mencari file BACPAC dari MyKosHub yang tersimpan di folder "MyKosHub" dengan nama "Database MyKosHub.bacpac", lalu klik Next.
10. Ganti nama database dari "Database MyKosHub" menjadi "mykoshub", lalu klik Next.
11. Tekan tombol Finish.
12. Tunggu sampai proses selesai dan tekan tombol Close.
13. Kembali ke folder "MyKosHub" dan buka "MyKosHub.sln" dengan Visual Studio.
14. Buka menu Data Sources untuk menambahkan Data Source baru dengan menekan ikon pertama bernama "Add New Data Source" saat di-hover.
15. Pilih Database sebagai Data Source Type-nya, lalu Next.
16. Pilih Dataset sebagai Database Model, lalu Next.
17. Pilih New Connection di halaman Choose Your Data Connection.
18. Pastikan Data Source adalah "Microsoft SQL Server (SqlClient)".
19. Pada bagian Server Name, tekan tombol drop down dan pilih server name yang sesuai saat login ke SSMS sebelumnya.
20. Untuk Authentication, gunakan "Windows Authentication" dengan Encrypt "Mandatory (True)" dan centang "Trust Server Certificate".
21. Lalu pada pilihan database, klik drop down dan pilih "mykoshub", lalu klik OK.
22. Kemudian, klik tombol Next.
23. Isi nama koneksi sesuai keinginan Anda, lalu klik Next.
24. Centang Tables dan Views.
25. Nama DataSet juga dibebaskan saja, lalu Finish.
26. Masuk ke Class dbConnect.cs yang dapat diakses melalui Solution Explorer.
27. Di string "cs" ganti "ASUSY\\SQLEXPRESS;" sesuai dengan server name saat login di SSMS sebelumnya.
28. Setelah menjalankan seluruh langkah-langkah ini, maka aplikasi MyKosHub sudah bisa dijalankan pada Visual Studio.

=========================================================================

Solusi untuk masalah yang mungkin ditemukan selama meng-install aplikasi:
* Tidak bisa connect ke database menggunakan SSMS/Data Source di Visual Studio
  1) Buka halaman Services di Window.
  2) Cari SQL Server (SQLEXPRESS), SQL Server Browser, dan SQL Server VSS Writer; pastikan ketiga hal ini dalam kondisi "Running".
  3) Coba lagi untuk melakukan tahap yang bermasalah sebelumnya.

=========================================================================

Dengan kondisi bahwa admin hanya dapat didaftarkan oleh kami sebagai pihak aplikasi MyKosHub, maka hanya ada satu akun admin yang tersedia. Untuk login sebagai admin, maka Anda dapat menggunakan email dan password berikut:
email     : admin@gmail.com
password  : ayu
