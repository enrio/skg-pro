package atbmtt;

import java.io.*;
import java.math.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;
import javax.crypto.*;

public class RSAKeyRestorationEM {
	public static void main(String[] args) {
		try {
			// Đọc và dựng khoá công khai từ file kpEM.txt
			BufferedReader reader = new BufferedReader(new FileReader("c:\\kpEM.txt"));
			String str_e = reader.readLine();
			String str_m = reader.readLine();
			reader.close();

			// Dựng khoá công khai kp
			BigInteger e = new BigInteger(str_e);
			BigInteger m = new BigInteger(str_m);
			RSAPublicKeySpec pbKeyspec = new RSAPublicKeySpec(m, e);
			KeyFactory keyfactor = KeyFactory.getInstance("RSA");
			RSAPublicKey kp = (RSAPublicKey) keyfactor
					.generatePublic(pbKeyspec);

			// Đọc và dựng khoá bí mật từ file ksEM.txt
			reader = new BufferedReader(new FileReader("c:\\ksEM.txt"));
			str_e = reader.readLine();
			str_m = reader.readLine();
			reader.close();

			e = new BigInteger(str_e);
			m = new BigInteger(str_m);
			RSAPrivateKeySpec prKeyspec = new RSAPrivateKeySpec(m, e);
			RSAPrivateKey ks = (RSAPrivateKey) keyfactor
					.generatePrivate(prKeyspec);

			// Tạo và khởi động Si phơ sử dụng khoá công khái kp để mã hoá
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.ENCRYPT_MODE, kp);

			// Mã hoá với khoá kp
			String msg = "Hello Mr. ZNGTFY!";
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

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
