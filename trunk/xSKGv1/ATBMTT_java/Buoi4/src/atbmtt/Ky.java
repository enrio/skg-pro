package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;
import javax.crypto.*;

public class Ky {
	public static void main(String[] args) {
		try {
			// Đọc khoá bí mật
			FileInputStream fis = new FileInputStream("c:\\ks.txt");
			byte[] buff = new byte[fis.available()];
			fis.read(buff);
			fis.close();

			// Dựng khoá
			PKCS8EncodedKeySpec spec = new PKCS8EncodedKeySpec(buff);
			KeyFactory keyfac = KeyFactory.getInstance("RSA");
			RSAPrivateKey ks = (RSAPrivateKey) keyfac.generatePrivate(spec);

			// Tạo và khởi động Si phơ với khoá bí mật ks
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.ENCRYPT_MODE, ks);

			// Đọc file thông báo
			fis = new FileInputStream("c:\\thong-bao.txt");
			FileOutputStream fos = new FileOutputStream("c:\\chu-ky.txt");

			// Cắt dữ liệu ra từng khối, kích thước <= 117 bytes
			int size = 117;
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
