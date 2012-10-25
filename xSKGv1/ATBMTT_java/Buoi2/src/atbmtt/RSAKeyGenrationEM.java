package atbmtt;

import java.io.*;
import java.math.*;
import java.security.*;
import java.security.interfaces.*;

public class RSAKeyGenrationEM {

	public static void main(String[] args) {
		try {
			// Sinh ngẫu nhiên 1 cặp khoá
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			// Tạo khoá công khai kp, khoá bí mật ks
			RSAPublicKey kp = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks = (RSAPrivateKey) key.getPrivate();

			// Lưu trữ khoá công khai kp vào file kpEM.txt
			BigInteger exponent = kp.getPublicExponent();
			BigInteger modulus = kp.getModulus();
			FileWriter wr = new FileWriter("c:\\kpEM.txt");
			wr.write(exponent.toString() + "\n");
			wr.write(modulus.toString() + "\n");
			wr.close();

			// Lưu trữ khoá bí mật ks vào file ksEM.txt
			wr = new FileWriter("c:\\ksEM.txt");
			exponent = ks.getPrivateExponent();
			modulus = ks.getModulus();
			wr.write(exponent.toString() + "\n");
			wr.write(modulus.toString() + "\n");
			wr.close();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
