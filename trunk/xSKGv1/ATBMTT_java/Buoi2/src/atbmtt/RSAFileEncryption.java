package atbmtt;

import java.io.*;
import java.security.interfaces.*;
import java.security.*;
import javax.crypto.*;

public class RSAFileEncryption {
	public static void main(String[] args) {
		try {
			// Sinh ngẫu nhiên 1 cặp khoá
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			// Tạo khoá công khai kp, khoá bí mật ks
			RSAPublicKey kp = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks = (RSAPrivateKey) key.getPrivate();

			// Tạo và khởi động Si phơ với khoá công khai kp
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.ENCRYPT_MODE, kp);

			// Chọn 1 file có kích thước 117 bytes
			FileInputStream fis = new FileInputStream("c:\\file.doc");
			FileOutputStream fos = new FileOutputStream("c:\\kq.cip");

			// Cắt dữ liệu ra từng khối, kích thước <= 117 bytes
			int size = 117;
			byte[] buff = new byte[size];

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

			// Đọc file mã hoá kq.cip và giãi mã lưu vào file kq.doc
			fis = new FileInputStream("c:\\kq.cip");
			fos = new FileOutputStream("c:\\kq.doc");

			// Khởi tạo Si phơ giải mã với khoá bí mật ks
			cp.init(Cipher.DECRYPT_MODE, ks);

			// Kích thước mỗi khối trong file mật là 128 bytes
			size = 128;
			buff = new byte[size];

			while (true) {
				int n = fis.read(buff);
				if (n <= 0)
					break;
				byte[] plain = cp.doFinal(buff, 0, n);
				fos.write(plain);
			}
			fis.close();
			fos.close();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
