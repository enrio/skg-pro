package atbmtt;

import java.io.*;

public class Thaydoi {
	public static void main(String[] args) {
		try {
			// Đọc file
			FileInputStream fis = new FileInputStream("c:\\toan.iso");
			byte[] buff = new byte[fis.available()];
			fis.read(buff);
			fis.close();

			// Thay doi 1 byte dau tien
			if (buff.length > 0)
				buff[0] += 1;

			FileOutputStream fos = new FileOutputStream("c:\\toan1.iso");
			fos.write(buff);
			fos.close();

			System.out.print("File da duoc thay doi!");

			// Check MD5 file goc
			String check = FileHasher.getMD5Checksum("c:\\toan.iso");
			System.out.print("File goc\n");
			System.out.print("MD5: " + check);

			System.out.println();

			// Check MD5 file da thay doi
			check = FileHasher.getMD5Checksum("c:\\toan1.iso");
			System.out.print("File bi thay doi\n");
			System.out.print("MD5: " + check);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
