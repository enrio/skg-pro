package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;
import javax.crypto.*;

public class Kiemtra {
	public static void main(String[] args) {
		try {
			// Đọc khoá công khai
			FileInputStream fis = new FileInputStream("c:\\kp.txt");
			byte[] buff = new byte[fis.available()];
			fis.read(buff);
			fis.close();

			// Dựng khoá
			X509EncodedKeySpec spec = new X509EncodedKeySpec(buff);
			KeyFactory keyfac = KeyFactory.getInstance("RSA");
			RSAPublicKey kp = (RSAPublicKey) keyfac.generatePublic(spec);

			// Tạo và khởi động Si phơ với khoá bí mật ks
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.DECRYPT_MODE, kp);

			// Đọc file chữ kí
			fis = new FileInputStream("c:\\chu-ky.txt");
			FileOutputStream fos = new FileOutputStream("c:\\so-sanh.txt");

			// Đọc dữ liệu từng khối, kích thước 128 bytes
			int size = 128;
			buff = new byte[size];

			while (true) {
				int n = fis.read(buff);
				if (n <= 0)
					break;
				byte[] cip = cp.doFinal(buff, 0, n);
				System.out.println("Size: " + cip.length);
				fos.write(cip);
			}
			fis.close();
			fos.close();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
