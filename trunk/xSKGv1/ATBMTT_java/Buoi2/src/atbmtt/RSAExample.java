package atbmtt;

import java.security.interfaces.*;
import java.security.*;
import javax.crypto.*;

public class RSAExample {
	public static void main(String[] args) {
		try {
			// Sinh ngẫu nhiên 1 cặp khoá
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			// Tạo khoá công khai kp, khoá bí mật ks
			RSAPublicKey kp = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks = (RSAPrivateKey) key.getPrivate();

			// Tạo và khởi động Si phơ
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.ENCRYPT_MODE, kp);

			// Mã hoá thông điệp
			String msg = "Hello Zng Tfy!";
			byte[] c = cp.doFinal(msg.getBytes());

			// In mã ra màn hình
			for (int i = 0; i < c.length; i++)
				System.out.print(c[i]);
			System.out.println();

			// Giải mã bằng khoá bí mật ks
			cp.init(Cipher.DECRYPT_MODE, ks);
			byte[] p = cp.doFinal(c);

			// In kết quả giải mã ra màn hình
			for (int i = 0; i < p.length; i++)
				System.out.print((char) p[i]);
			System.out.println();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
