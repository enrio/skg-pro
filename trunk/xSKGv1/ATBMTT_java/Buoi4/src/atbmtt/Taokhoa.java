package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;

public class Taokhoa {
	public static void main(String[] args) {
		try {
			// Sinh ngẫu nhiên 1 cặp khoá
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			// Tạo khoá công khai kp, khoá bí mật ks
			RSAPublicKey kp = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks = (RSAPrivateKey) key.getPrivate();

			// Lưu trữ khoá công khai kp vào file kp.txt
			FileOutputStream fos = new FileOutputStream("c:\\kp.txt");
			fos.write(kp.getEncoded());
			fos.close();

			// Lưu trữ khoá bí mật ks vào file ks.txt
			fos = new FileOutputStream("c:\\ks.txt");
			fos.write(ks.getEncoded());
			fos.close();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
