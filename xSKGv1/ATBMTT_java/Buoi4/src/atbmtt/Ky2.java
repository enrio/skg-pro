package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;

public class Ky2 {
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

			// Tạo chữ ký
			Signature signer = Signature.getInstance("MD5withRSA");
			signer.initSign(ks);

			// Đọc file thông báo
			fis = new FileInputStream("c:\\thong-bao.txt");
			FileOutputStream fos = new FileOutputStream("c:\\chu-ky2.txt");

			// Cắt dữ liệu ra từng khối, kích thước <= 117 bytes
			int size = 117;
			buff = new byte[size];

			while (true) {
				int n = fis.read(buff);
				if (n <= 0)
					break;
				signer.update(buff, 0, n);
			}

			byte[] kq = signer.sign();
			fos.write(kq);

			fis.close();
			fos.close();
			
			System.out.print("Ky thanh cong!");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
