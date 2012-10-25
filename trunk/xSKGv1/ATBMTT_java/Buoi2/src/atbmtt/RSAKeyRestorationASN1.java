package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;
import javax.crypto.*;

public class RSAKeyRestorationASN1 {
	public static void main(String[] args) {
		try {
			// Đọc và dựng khoá công khai từ file kp.txt
			FileInputStream fis = new FileInputStream("c:\\kp.txt");
			byte[] buffer = new byte[fis.available()];
			fis.read(buffer);
			fis.close();

			// Dựng khoá công khai kp
			X509EncodedKeySpec pbKeyspec = new X509EncodedKeySpec(buffer);
			KeyFactory keyfactor = KeyFactory.getInstance("RSA");
			RSAPublicKey kp = (RSAPublicKey) keyfactor
					.generatePublic(pbKeyspec);

			// Đọc và dựng khoá bí mật từ file ks.txt
			fis = new FileInputStream("c:\\ks.txt");
			buffer = new byte[fis.available()];
			fis.read(buffer);
			fis.close();

			// Dựng khoá bí mật ks
			PKCS8EncodedKeySpec prKeyspec = new PKCS8EncodedKeySpec(buffer);
			RSAPrivateKey ks = (RSAPrivateKey) keyfactor
					.generatePrivate(prKeyspec);

			// Tạo và khởi động Si phơ sử dụng khoá công khái kp để mã hoá
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.ENCRYPT_MODE, kp);

			// Mã hoá với khoá kp
			String msg = "Hello Zng Tfy!";
			byte[] c = cp.doFinal(msg.getBytes());

			// In kết quả mã hoá
			for (int i = 0; i < c.length; i++)
				System.out.print(c[i]);
			System.out.println();

			// Khởi động Si phơ sử dụng khoá bí mật ks để giải mã
			cp.init(Cipher.DECRYPT_MODE, ks);
			byte[] p = cp.doFinal(c);

			// In kết quả giải mã
			for (int i = 0; i < p.length; i++)
				System.out.print((char) p[i]);
			System.out.println();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
